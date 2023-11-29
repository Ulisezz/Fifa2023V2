namespace Fifa2023.Core;
public interface IAdo
{
    
    void AltaFutbolistas(Futbolistas futbolistas);
    public Futbolistas? GetFutbolistas(int idFutbolista);
    public List<Futbolistas> GetFutbolistas();
    
    void AltaHAbilidades(Habilidades habilidades);
    public Habilidades? GetHabilidades(int IdHabilidad);
    public List<Habilidades> GetHabilidades();

    void AltaJugadores(Jugadores jugadores);
    public Jugadores? GetJugadores(int idJugador);
    public List<Jugadores> GetJugadores();

    void AltaPosesion(Posesion posesion);
    public Posesion? GetPosesion(int idJugador,int idFutbolista);
    public List<Posesion> GetPosesion();
    void AltaPosesionHabilidad(PosesionHabilidad posesionHabilidad);
    public PosesionHabilidad? GetPosesionHabilidad(int IdHabilidad,int idFutbolista);
    public List<PosesionHabilidad> GetPosesionHabilidad();
    void AltaPosiciones(Posiciones posiciones);
    public Posiciones? GetPosiciones(int idPosicion, string Posicion);
    public List<Posiciones> GetPosiciones();
    void AltaTransferencias(Transferencias transferencias);
    public Transferencias? GetTransferencias(int idTransferencia);
    public List<Transferencias> GetTransferencias();
}
