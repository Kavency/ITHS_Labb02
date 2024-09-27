# ITHS_Labb02
## Dungeon Crawler Deluxe

För godkänt:
Appen ska vara kompatibel med, och kunna läsa in filen “Level1.txt”, och korrekt hantera de olika elementen enligt beskrivningen i labben.
Fiendetyperna rat och snakes ska finnas och ha unika stats. Deras beteenden (rörelsemönster) ska fungera enligt beskrivningen i labben.
Appen ska ha abstrakta basklasser “LevelElement” och “Enemy”. Klassen “Wall” ärver direkt av “LevelElement”, och klasserna “Rat” och “Snake” ärver direkt av “Enemy” (indirekt av “LevelElement”).
Spelaren ska kunna flytta ett steg per omgång (upp/ner/höger/vänster), men inte genom väggar eller fiender.
Spelaren har ett synfält som sträcker sig i en radie 5 steg bort från spelarens position. Fiender som är utanför synfältet syns ej (men uppdateras ändå varje omgång); däremot försvinner inte väggarna när man väl upptäckt dem första gången.
Går spelaren på en fiende ska attack, defence, och skada avgöras med hjälp av tärningsslag; varpå fienden direkt gör en motattack (om den överlever).
Går en fiende in i spelaren görs samma sekvens som i föregående punkt, men fienden attackerar först; varpå spelaren gör en motattack (om den överlever).
