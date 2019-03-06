USE Teste

CREATE TABLE Patrimonio(
MarcaId INT,
Nome VARCHAR (50) NOT NULL,
Descricao VARCHAR (150),
NumeroTombo INT IDENTITY(1,1),
FOREIGN KEY (MarcaId) REFERENCES Marca(MarcaId) ON DELETE CASCADE
)
















