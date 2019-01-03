using System;
using System.Collections.Generic;
using System.Linq;

public class Manager
{
    private List<Clinic> clinics;
    private List<Pet> pets;

    public Manager()
    {
        this.clinics = new List<Clinic>();
        this.pets = new List<Pet>();
    }

    public void CreateClinic(Clinic clinicName)
    {
        this.clinics.Add(clinicName);
    }

    public void CreatePet(Pet pet)
    {
        this.pets.Add(pet);
    }

    internal bool AddPet(string petName, string clinicName)
    {
        var currentPet = this.pets.FirstOrDefault(x => x.Name == petName);
        var currentClinic = this.clinics.FirstOrDefault(x => x.Name == clinicName);

        if (currentPet == null || currentPet == null)
        {
            return false;
        }

        return currentClinic.AddPet(currentPet);
    }

    public bool Release(string clinicName)
    {
        var currentClinic = this.clinics.FirstOrDefault(x => x.Name == clinicName);
        if (currentClinic == null)
        {
            return false;
        }

        return currentClinic.Release();
    }

    public bool HasEmptyRooms(string clinicName)
    {
        var currentClinic = this.clinics.FirstOrDefault(x => x.Name == clinicName);
        if (currentClinic == null)
        {
            return false;
        }

        return currentClinic.HasEmptyRooms();
    }

    public void PrintAll(string clinicName)
    {
        var currentClinic = this.clinics.FirstOrDefault(x => x.Name == clinicName);
        Console.WriteLine(currentClinic.PrintAllPets());
    }

    public void Print(string clinicName, int roomNumber)
    {
        var currentClinic = this.clinics.FirstOrDefault(x => x.Name == clinicName);
        Console.WriteLine(currentClinic.PrintSpecifiedRoom(roomNumber));
    }
}