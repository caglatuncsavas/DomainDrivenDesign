﻿//using System.Security.Cryptography.X509Certificates;

//MemoryCache memoryCache = new();
//memoryCache.CreateCache();

//abstract class Cache
//{
//    public virtual void CreateCache()
//    {

//    }
//}

//class MemoryCache : Cache
//{
//    public override void CreateCache()
//    {
//        System.Console.WriteLine("Memory Cache Created");
//    }
//}

//class RedisCache : Cache
//{
//    public override void CreateCache()
//    {
//        System.Console.WriteLine("Redis Cache Created");
//    }
//}


static void EntityMethod()
{
    User user1 = new()
    {
        Id = 1,
        FirstName = "Çağla",
        LastName = "Çağla Tunç Savaş",
        Email = "caglatuncsavas@gmail.com"
    };

    User user2 = new()
    {
        Id = 1,
        FirstName = "Çağla",
        LastName = "Çağla Tunç Savaş",
        Email = "caglatuncsavas@gmail.com"
    };

    var result = user1 == user2;

    //var result = user1.Equals(user2);
    Console.WriteLine($"user1 user2'ye eşit mi?: {result}"); //Referans olarak eşit olmadığı ve newlenerek farklı instancelar aldığı için false döner.
    Console.ReadLine();
}

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj is not User user) return false;
        if (obj.GetType() != typeof(User)) return false;
        return user.Id == Id;
    }

    public static bool operator ==(User left, User right)
    {
        if (left is null || right is null) return false;
        if (left.GetType() != right.GetType()) return false;
        return left.Id == right.Id;
    }

    public static bool operator !=(User left, User right)
    {
        if (left is null || right is null) return false;
        if (left.GetType() != right.GetType()) return false;
        return left.Id == right.Id;
    }
}