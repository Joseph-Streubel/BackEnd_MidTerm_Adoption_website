using midterm_project.Models;

namespace midterm_project.Repositories;

public interface IPetRepository{
    IEnumerable<Pets> GetAllPets();
    Pets GetPetsById(int petId);
    Pets CreatePet(Pets newPet);
    Pets UpdatePet(Pets newPet);
    void DeletePetById(int petId);
}