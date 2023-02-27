using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class EFPetRepository : IPetRepository{
    private readonly PetDbContext _context;

    public EFPetRepository(PetDbContext context){
        _context = context;
    }

    public Pets CreatePet(Pets newPet)
    {
        _context.Pets.Add(newPet);
        _context.SaveChanges();
        return newPet;
    }

    public void DeletePetById(int petId)
    {
        var pet = _context.Pets.Find(petId);
        if (pet != null){
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Pets> GetAllPets()
    {
        return _context.Pets.ToList();
    }

    public Pets GetPetsById(int petId)
    {
        return _context.Pets.SingleOrDefault(p => p.PetId == petId);
    }

    public Pets UpdatePet(Pets newPet)
    {
        var originalPet = _context.Pets.Find(newPet.PetId);
        if(originalPet != null){
            originalPet.PetName = newPet.PetName;
            originalPet.ImgUrl = newPet.ImgUrl;
            originalPet.PetDescription = newPet.PetDescription;
            originalPet.PetAge = newPet.PetAge;
            _context.SaveChanges();
        }

        return originalPet;
    }
}