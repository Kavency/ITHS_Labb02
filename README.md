# ITHS_Labb02
## Dungeon Crawler Deluxe
Mission.... Create a simple Dungeon Crawler console game. Enjoy!


### För godkänt:
- [x] Appen ska vara kompatibel med, och kunna läsa in filen “Level1.txt”.
  - [x] Korrekt hantera de olika elementen enligt beskrivningen i labben.
- [x] Fiendetyperna rat och snakes ska finnas.
  - [x] Ha unika stats.
  - [x] Deras beteenden (rörelsemönster) ska fungera enligt beskrivningen i labben.
- [x] Appen ska ha abstrakta basklasser “LevelElement” och “Enemy”.
  - [x] Klassen “Wall” ärver direkt av “LevelElement”.
  - [x] Klasserna “Rat” och “Snake” ärver direkt av “Enemy” (indirekt av “LevelElement”).
- [x] Spelaren ska kunna flytta ett steg per omgång (upp/ner/höger/vänster).
  - [x] Inte genom väggar eller fiender.
- [x] Spelaren har ett synfält som sträcker sig i en radie 5 steg bort från spelarens position.
  - [x] Fiender som är utanför synfältet syns ej (men uppdateras ändå varje omgång).
  - [x] Väggarna försvinner inte när man väl upptäckt dem första gången.
- [x] Går spelaren på en fiende ska attack, defence, och skada avgöras med hjälp av tärningsslag.
  - [x] Fienden gör direkt en motattack (om den överlever).
- [x] Går en fiende in i spelaren görs samma sekvens som i föregående punkt, men fienden attackerar först.
  - [x] Spelaren gör en motattack (om den överlever).
