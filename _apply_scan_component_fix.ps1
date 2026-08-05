# Run from the CS2-AllTransitTrucks repository root.
# Updates the existing scan report without replacing the two large scan files.

$ErrorActionPreference = "Stop"
$utf8NoBom = New-Object System.Text.UTF8Encoding($false)

$scanPath = Join-Path $PWD "AllTransitTrucks\Systems\Probes\PrefabScanSystem.cs"
$sectionsPath = Join-Path $PWD "AllTransitTrucks\Systems\Probes\PrefabScanSystem.ReportSections.cs"

if (-not (Test-Path $scanPath) -or -not (Test-Path $sectionsPath)) {
    throw "Run this script from the CS2-AllTransitTrucks repository root."
}

$scan = [IO.File]::ReadAllText($scanPath).Replace("`r`n", "`n")

$oldExtractor = @'
                // Industrial extractor companies
                Append("== Industrial Extractor TransportCompanies (for Extractor trucks slider) ==");
                Append("Filter: name starts with Industrial_ AND contains Extractor/Coal/Stone/Mine/Quarry. Skips CurMaxTransports=0. Deduped by name.");

                HashSet<string> seenExtractors = new(StringComparer.OrdinalIgnoreCase);

                foreach ((RefRO<TransportCompanyData> tcRef, Entity e) in SystemAPI
                             .Query<RefRO<TransportCompanyData>>()
                             .WithAll<PrefabData>()
                             .WithEntityAccess())
                {
                    if (truncated) break;

                    string name = NameOf(e);
                    if (IsExcludedName(name))
                        continue;

                    if (!IsTargetIndustrialExtractorCompany(name))
                        continue;

                    TransportCompanyData tc = tcRef.ValueRO;

                    if (tc.m_MaxTransports == 0)
                        continue;

                    if (!seenExtractors.Add(name))
                        continue;

                    extractorCompanies++;
                    Append($"- {name} ({e.Index}:{e.Version}) CurMaxTransports={tc.m_MaxTransports}");
                }
'@

$newExtractor = @'
                // Exact component filter used by IndustrySystem.
                Append("== Extractor companies matched by ATT ==");
                Append("Filter: TransportCompanyData + ExtractorCompanyData + PrefabData. No prefab-name list.");

                foreach ((RefRO<Game.Companies.TransportCompanyData> tcRef, Entity e) in SystemAPI
                             .Query<RefRO<Game.Companies.TransportCompanyData>>()
                             .WithAll<Game.Prefabs.ExtractorCompanyData, Game.Prefabs.PrefabData>()
                             .WithEntityAccess())
                {
                    if (truncated) break;

                    Game.Companies.TransportCompanyData tc = tcRef.ValueRO;
                    if (tc.m_MaxTransports <= 0)
                        continue;

                    extractorCompanies++;
                    Append($"- {NameOf(e)} ({e.Index}:{e.Version}) CurMaxTransports={tc.m_MaxTransports}");
                }
'@

if ($scan.Contains($oldExtractor)) {
    $scan = $scan.Replace($oldExtractor, $newExtractor)
    [IO.File]::WriteAllText($scanPath, $scan, $utf8NoBom)
    Write-Host "Updated component-based extractor scan."
}
elseif ($scan.Contains("== Extractor companies matched by ATT ==")) {
    Write-Host "Extractor scan already updated."
}
else {
    throw "Could not find the old extractor scan block."
}

$sections = [IO.File]::ReadAllText($sectionsPath).Replace("`r`n", "`n")

$oldLaneQuery = @'
            HashSet<Entity> wearPrefabs = new();

            foreach ((RefRO<LaneDeteriorationData> _, Entity prefabEntity) in SystemAPI
                         .Query<RefRO<LaneDeteriorationData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                wearPrefabs.Add(prefabEntity);
            }
'@

$newLaneQuery = @'
            HashSet<Entity> wearPrefabs = new();

            // Avoid a duplicate SystemAPI.Query signature across this partial system.
            EntityQuery wearPrefabQuery = SystemAPI.QueryBuilder()
                .WithAll<LaneDeteriorationData, PrefabData>()
                .Build();

            using (NativeArray<Entity> wearPrefabEntities =
                   wearPrefabQuery.ToEntityArray(Allocator.Temp))
            {
                for (int i = 0; i < wearPrefabEntities.Length; i++)
                {
                    wearPrefabs.Add(wearPrefabEntities[i]);
                }
            }
'@

if ($sections.Contains($oldLaneQuery)) {
    $sections = $sections.Replace($oldLaneQuery, $newLaneQuery)
    Write-Host "Updated duplicate lane query."
}
elseif ($sections.Contains("Avoid a duplicate SystemAPI.Query signature")) {
    Write-Host "Lane query already updated."
}
else {
    throw "Could not find the old lane query block."
}

# The component-based scan no longer needs the old prefab-name helper.
$helperPattern = '(?s)\n        private static bool IsTargetIndustrialExtractorCompany\(string name\)\n        \{.*?\n        \}\n\n        private static bool IsExcludedName'
if ([regex]::IsMatch($sections, $helperPattern)) {
    $sections = [regex]::Replace(
        $sections,
        $helperPattern,
        "`n        private static bool IsExcludedName",
        1)
    Write-Host "Removed old extractor name filter."
}

[IO.File]::WriteAllText($sectionsPath, $sections, $utf8NoBom)
Write-Host "Scan component fix finished."
