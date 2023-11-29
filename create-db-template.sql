DROP DATABASE IF EXISTS 5to_FIFA;
CREATE DATABASE 5to_FIFA;
USE 5to_FIFA;

CREATE TABLE Jugadores (
	idJugador TINYINT PRIMARY KEY,
    usuario VARCHAR(45),
    nombre VARCHAR(45),
    apellido VARCHAR(45),
    contraseña VARCHAR(64),
    monedas MEDIUMINT UNSIGNED,
    CONSTRAINT UQ_Usuario UNIQUE (usuario)
);

CREATE TABLE Habilidades (
	idHabilidad TINYINT PRIMARY KEY,
    nombre VARCHAR(45),
    descripcion VARCHAR(45)
);

CREATE TABLE Posiciones (
	idPosicion TINYINT PRIMARY KEY,
    Posicion VARCHAR(45)
);
CREATE TABLE Futbolistas(
	idFutbolista SMALLINT PRIMARY KEY,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    nacimiento DATE,
    velocidad TINYINT,
    remate TINYINT,
    pase TINYINT,
    defensa TINYINT,
    idPosicion TINYINT,
    idHabilidad TINYINT,
    CONSTRAINT FK_Futbolistas_Posiciones FOREIGN KEY (idPosicion)
		REFERENCES Posiciones (idPosicion),
    CONSTRAINT FK_Futbolistas_Habilidades FOREIGN KEY (idHabilidad)
		REFERENCES Habilidades (idHabilidad)
);

CREATE TABLE PosesionHabilidad (
	idFutbolista SMALLINT,
    idHabilidad TINYINT,
	CONSTRAINT FK_PH_Futbolistas FOREIGN KEY (idFutbolista)
		REFERENCES Futbolistas (idFutbolista),
	CONSTRAINT FK_PH_Habilidades FOREIGN KEY (idHabilidad)
		REFERENCES Habilidades (idHabilidad)
);
CREATE TABLE Posesion (
	idFutbolista SMALLINT,
    idJugador TINYINT,
    CONSTRAINT FK_Posesion_Futbolistas FOREIGN KEY (idFutbolista)
		REFERENCES Futbolistas (idFutbolista),
	CONSTRAINT FK_Posesion_Jugadores FOREIGN KEY (idJugador)
		REFERENCES Jugadores (idJugador)
);
CREATE TABLE Transferencias (
	idTransferencia TINYINT PRIMARY KEY,
	fecha DATETIME,
    precio MEDIUMINT UNSIGNED,
    idVendedor MEDIUMINT,
    idComprador MEDIUMINT,
    idFutbolista SMALLINT,
    Transferencia_exitosa BOOL,
	CONSTRAINT FK_Transferencias_Futbolistas FOREIGN KEY (idFutbolista)
		REFERENCES Futbolistas (idFutbolista)
);
