using System;
using System.Collections.Generic;
using System.Text;

public class Clinic
{
    private int roomsCount;
    private int firstRoomIndex;

    public Clinic(string name, int roomsCount)
    {
        this.Name = name;
        this.RoomsCount = roomsCount;
        this.Pets = new Pet[roomsCount];
        this.firstRoomIndex = this.Pets.Length / 2;
    }

    public string Name { get; set; }

    public int RoomsCount
    {
        get
        {
            return this.roomsCount;
        }
        set
        {
            if (value % 2 == 0 || value < 1 || value > 101)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.roomsCount = value;
        }
    }

    public Pet[] Pets { get; set; }


    public bool AddPet(Pet pet)
    {
        for (int i = 0; i <= this.firstRoomIndex; i++)
        {
            if (this.Pets[this.firstRoomIndex - i] == null)
            {
                this.Pets[this.firstRoomIndex - i] = pet;
                return true;
            }

            if (this.Pets[this.firstRoomIndex + i] == null)
            {
                this.Pets[this.firstRoomIndex + i] = pet;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        for (int i = this.firstRoomIndex; i < this.Pets.Length; i++)
        {
            if (this.Pets[i] != null)
            {
                this.Pets[i] = null;

                return true;
            }
        }

        for (int i = 0; i < this.firstRoomIndex; i++)
        {
            if (this.Pets[i] != null)
            {
                this.Pets[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        for (int i = 0; i < this.Pets.Length; i++)
        {
            if (this.Pets[i] == null)
            {
                return true;
            }
        }

        return false;
    }

    public string PrintAllPets()
    {
        var sb = new StringBuilder();
        foreach (var pet in this.Pets)
        {
            if (pet == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine($"{pet.Name} {pet.Age} {pet.Kind}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string PrintSpecifiedRoom(int roomNumber)
    {
        var targetRoom = this.Pets[roomNumber-1];

        if (targetRoom == null)
        {
            return "Room empty";
        }
        else
        {
            return $"{targetRoom.Name} {targetRoom.Age} {targetRoom.Kind}";
        }
    }
}