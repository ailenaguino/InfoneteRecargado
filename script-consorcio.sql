use PW3_TP_20202C;

ALTER TABLE Unidad
ADD CONSTRAINT cascada_unidad FOREIGN KEY(idConsorcio)
REFERENCES Consorcio (idConsorcio)
ON DELETE CASCADE

ALTER TABLE Gasto
ADD CONSTRAINT cascada_gasto FOREIGN KEY(idConsorcio)
REFERENCES Consorcio (idConsorcio)
ON DELETE CASCADE
