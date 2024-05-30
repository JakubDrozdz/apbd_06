namespace apbd_06.Repositiories;

public interface IMedicamentRepository
{
    public Task<bool> IsMedicamentExist(int medicamentId);
}