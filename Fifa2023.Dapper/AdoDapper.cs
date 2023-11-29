using Dapper;
using MySqlConnector;
using Fifa2023.Core;
using System.Data;

namespace Fifa2023.Dapper;

public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;

    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);


    #region Futbolistas
    private static readonly string _queryFutbolistas
    = @"SELECT * FROM Futbolistas";
    private static readonly string _queryFutbolistasporID 
    = @"SELECT * FROM Futbolistas WHERE IdFutbolista = @unIdFutbolista";
    private static readonly string _queryAltaFutbolistas
    = @"INSERT INTO Futbolistas VALUES (@IdFutbolistas, @IdPosicion, @Nombre, @Apellido, @Nacimiento, @Velocidad, @Remate, @Pase, @Defensa)";
    public void AltaFutbolistas(Futbolistas futbolistas)
        => _conexion.Execute(
                _queryAltaFutbolistas,
                new
                {
                    IdFutbolista = futbolistas.IdFutbolista,
                    IdPosicion = futbolistas.IdPosicion,
                    Nombre = futbolistas.Nombre,
                    Apellido = futbolistas.Apellido,
                    Nacimiento = futbolistas.Nacimiento,
                    Velocidad = futbolistas.Velocidad,
                    Remate = futbolistas.Remate,
                    Pase = futbolistas.Pase,
                    Defensa = futbolistas.Defensa
                }
            );
    public Futbolistas? GetFutbolistas(int IdFutbolista)
        => _conexion.QueryFirstOrDefault<Futbolistas>(_queryFutbolistasporID, new { unIdFutbolista = IdFutbolista });

    public List<Futbolistas> GetFutbolistas()
        => _conexion.Query<Futbolistas>(_queryFutbolistas).ToList();
    #endregion

    #region Habilidades
    private static readonly string _queryHabilidades
    = @"SELECT * FROM Habilidades";
    private static readonly string _queryHabilidadesporID 
    = @"SELECT * FROM Habilidades WHERE IdHabilidad = @unIdHabilidad";
    private static readonly string _queryAltaHabilidades
    = @"INSERT INTO Futbolistas VALUES (@IdHabilidad, @Nombre, @Descripcion)";
    public void AltaHAbilidades(Habilidades habilidades)
        => _conexion.Execute(
                _queryAltaHabilidades,
                new
                {
                    IdHabilidad = habilidades.IdHabilidad,
                    Nombre = habilidades.Nombre,
                    Descripcion = habilidades.Descripcion
                }
            );

    public Habilidades? GetHabilidades(int IdHabilidad)
        => _conexion.QueryFirstOrDefault<Habilidades>(_queryHabilidadesporID, new { unIdHabilidad = IdHabilidad });

    public List<Habilidades> GetHabilidades()
        => _conexion.Query<Habilidades>(_queryHabilidades).ToList();

#endregion
    
    #region Jugadores
    private static readonly string _queryJugadores
    = @"SELECT * FROM Jugadores";
    private static readonly string _queryJugadoresporID 
    = @"SELECT * FROM Jugadores WHERE IdJugador = @unIdJugador";
    private static readonly string _queryAltaJugadores
    = @"INSERT INTO Jugadores VALUES (@IdJugadores, @Nombre, @Apellido, @Contrasena, @Monedas)";
    public void AltaJugadores(Jugadores jugadores)
        => _conexion.Execute(
                _queryAltaJugadores,
                new
                {
                    IdJugador = jugadores.IdJugador,
                    Nombre = jugadores.Nombre,
                    Apellido = jugadores.Apellido,
                    Contrasena = jugadores.Contrasena,
                    Monedas = jugadores.Monedas
                }
            );

    public Jugadores? GetJugadores(int IdJugador)
        => _conexion.QueryFirstOrDefault<Jugadores>(_queryJugadoresporID, new { unIdJugador = IdJugador });


    public List<Jugadores> GetJugadores()
        => _conexion.Query<Jugadores>(_queryJugadores).ToList();

    #endregion

    #region Posesion
    private static readonly string _queryPosesion
    = @"SELECT * FROM Posesion";
    private static readonly string _queryPosesionporID 
    = @"SELECT * FROM Posesion WHERE IdJugador =10";
    private static readonly string _queryAltaPosesion
    = @"INSERT INTO Posesion VALUES (@IdFutbolista, @IdJugador)";
    public void AltaPosesion(Posesion posesion)
        => _conexion.Execute(
                _queryAltaPosesion,
                new
                {
                    IdFutbolista = posesion.IdFutbolista,
                    IdJugador = posesion.IdJugador
                }
            );

    public Posesion? GetPosesion(int IdJugador, int IdFutbolista)
        => _conexion.QueryFirstOrDefault<Posesion>(_queryPosesionporID, new { unIdJugador = IdJugador, unIdFutbolista = IdFutbolista });


    public List<Posesion> GetPosesion()
        => _conexion.Query<Posesion>(_queryPosesion).ToList();

    #endregion

    #region PosesionHabilidad
        private static readonly string _queryPosesionHabilidad
    = @"SELECT * FROM PosesionHabilidad";
    private static readonly string _queryPosesionHabilidadporID 
    = @"SELECT * FROM PosesionHabilidad WHERE IdFutbolista = @unIdFutbolista";
    private static readonly string _queryAltaPosesionHabilidad
    = @"INSERT INTO PosesionHabilidad VALUES (@IdFutbolista, @IdHabilidad)";
    public void AltaPosesionHabilidad(PosesionHabilidad posesionHabilidad)
        => _conexion.Execute(
                _queryAltaPosesionHabilidad,
                new
                {
                    IdFutbolista = posesionHabilidad.IdFutbolista,
                    IdHabilidad = posesionHabilidad.IdHabilidad
                }
            );

    public PosesionHabilidad? GetPosesionHabilidad(int IdHabilidad, int IdFutbolista)
        => _conexion.QueryFirstOrDefault<PosesionHabilidad>(_queryPosesionHabilidadporID, new {unIdFutbolista = IdFutbolista, unIdHabilidad = IdHabilidad });


    public List<PosesionHabilidad> GetPosesionHabilidad()
        => _conexion.Query<PosesionHabilidad>(_queryPosesionHabilidad).ToList();


    #endregion

    #region Posiciones
    private static readonly string _queryPosiciones
    = @"SELECT * FROM Posiciones";
    private static readonly string _queryPosicionesporID 
    = @"SELECT * FROM Posiciones WHERE IdPosicion = @unIdPosicion";
    private static readonly string _queryAltaPosiciones
    = @"INSERT INTO Posiciones VALUES (@IdPosicion, @Posicion)";
    public void AltaPosiciones(Posiciones posiciones)
        => _conexion.Execute(
                _queryAltaPosiciones,
                new
                {
                    IdPosicion = posiciones.IdPosicion,
                    Posicion = posiciones.Posicion
                }
            );

    public Posiciones? GetPosiciones(int idPosicion, string Posicion)
        => _conexion.QueryFirstOrDefault<Posiciones>(_queryPosicionesporID, new {unIdPosicion = idPosicion, unPosicion = Posicion });


    public List<Posiciones> GetPosiciones()
        => _conexion.Query<Posiciones>(_queryPosiciones).ToList();

    #endregion

    #region Transferencias
    private static readonly string _queryTransferencias
    = @"SELECT * FROM Transferencias";
    private static readonly string _queryTransferenciasporID
    = @"SELECT * FROM Transferencias WHERE IdTransferencia = @unIdTransferencia";
    private static readonly string _queryAltaTransferencias
    = @"INSERT INTO Transferencias VALUES (@IdTransferencia, @IdVendedor, @IdComprador, @IdFutbolista, @Fecha, @Precio, @Transferencia_exitosa)";
    public void AltaTransferencias(Transferencias transferencias)
        => _conexion.Execute(
                _queryAltaTransferencias,
                new
                {
                    IdTransferencia = transferencias.IdTransferencia,
                    IdVendedor = transferencias.IdVendedor,
                    IdComprador = transferencias.IdComprador,
                    IdFutbolista = transferencias.IdFutbolista,
                    Fecha = transferencias.Fecha,
                    Precio = transferencias.Precio,
                    Transferencia_exitosa = transferencias.Transferencia_exitosa
                }
            );

    public Transferencias? GetTransferencias(int idTransferencia)
        => _conexion.QueryFirstOrDefault<Transferencias>(_queryTransferenciasporID, new {unIdTransferencia = idTransferencia});


    public List<Transferencias> GetTransferencias()
        => _conexion.Query<Transferencias>(_queryTransferencias).ToList();

    #endregion

}