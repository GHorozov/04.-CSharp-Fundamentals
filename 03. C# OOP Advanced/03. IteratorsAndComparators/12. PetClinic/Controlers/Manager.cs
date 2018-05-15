using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Manager
{
    private List<Pet> petList;
    private List<Clinic> clinicList;

    public Manager()
    {
        this.petList = new List<Pet>();
        this.clinicList = new List<Clinic>();
    }

    public void CreatePet(Pet pet)
    {
        petList.Add(pet);
    }

    public void CreateClinic(Clinic clinic)
    {
        clinicList.Add(clinic);
    }

    public bool AddPetToClinic(string petName, string clinicName)
    {
        Pet currentPet = GetPetWithName(petName); // if there is pet with this name
        Clinic currentClinic = GetClinicWithName(clinicName); // if there is clinic with this name

        return currentClinic.AddPetToClinic(currentPet); //add pet to this clinic(clinicName) and return if is in(true) or is not(false)
    }

    public bool ReleasePet(string clinicName)
    {
        var currentClinic = this.GetClinicWithName(clinicName);

        return currentClinic.ReleasePetFromClinic();
    }


    public bool HasEmptyRoom(string clinicName)
    {
        var currentClinic = this.GetClinicWithName(clinicName);

        return currentClinic.HasEmpty();
    }

    public string PrintAll(string clinicName)
    {
        var currentClinic = this.GetClinicWithName(clinicName);

        return currentClinic.GetAllRoomsToPrint();
    }

    public string Print(string clinicName, int room)
    {
        var currentClinic = this.GetClinicWithName(clinicName);

        return currentClinic.GetRoomToPrint(room);
    }

    private Clinic GetClinicWithName(string clinicName)
    {
        var currentClinic = this.clinicList.FirstOrDefault(x => x.Name == clinicName);

        if (currentClinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return currentClinic;
    }

    private Pet GetPetWithName(string petName)
    {
        var currentPet = this.petList.FirstOrDefault(x => x.Name == petName);

        if (currentPet == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return currentPet;
    }
}

