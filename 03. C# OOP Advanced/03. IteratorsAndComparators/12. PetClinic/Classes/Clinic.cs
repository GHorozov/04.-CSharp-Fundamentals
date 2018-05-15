using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Clinic : IComparable<Clinic>
{
    private string name;
    private Pet[] allRooms;
    private readonly int firstRoomIndex;


    public Clinic(string name, int roomsCount)
    {
        this.Name = name;
        this.ValidateNumberOfRooms(roomsCount);
        this.allRooms = new Pet[roomsCount];
        this.firstRoomIndex = this.allRooms.Length / 2;
    }

    private void ValidateNumberOfRooms(int roomsCount)
    {
        if (roomsCount % 2 == 0 || roomsCount < 1 || roomsCount > 101)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int CompareTo(Clinic other)
    {
        return this.name.CompareTo(other.name);
    }

    public bool AddPetToClinic(Pet pet)
    {
        for (int i = 0; i <= this.firstRoomIndex; i++)
        {
            if (this.allRooms[this.firstRoomIndex - i] == null)
            {
                this.allRooms[this.firstRoomIndex - i] = pet;

                return true;
            }

            if (this.allRooms[this.firstRoomIndex + i] == null)
            {
                this.allRooms[this.firstRoomIndex + i] = pet;
                return true;
            }
        }

        return false;
    }

    internal bool ReleasePetFromClinic()
    {
        for (int i = this.firstRoomIndex; i < this.allRooms.Length; i++)
        {
            if (this.allRooms[i] != null)
            {
                this.allRooms[i] = null;

                return true;
            }
        }

        for (int i = 0; i < this.firstRoomIndex; i++)
        {
            if (this.allRooms[i] != null)
            {
                this.allRooms[i] = null;

                return true;
            }
        }

        return false;
    }

    internal bool HasEmpty()
    {
        return this.allRooms.Any(x => x == null);
    }

    internal string GetAllRoomsToPrint()
    {
        var sb = new StringBuilder();

        foreach (var room in this.allRooms)
        {
            if (room == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine(room.ToString());
            }
        }

        return sb.ToString().Trim();
    }

    internal string GetRoomToPrint(int room)
    {
        room--;

        if (room < 0 || room >= this.allRooms.Length)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return (this.allRooms[room] == null)
            ? "Room empty"
            : this.allRooms[room].ToString();

    }
}

