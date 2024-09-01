
using System.Collections.Generic;

namespace Models.Stock;
public static class BrokerSystem
{
    private static Dictionary<string, User> userIdToUserMapping { get; } = new();
    public static void AddUser(string userId)
    {
        userIdToUserMapping[userId] = new User(userId);
    }
    public static void RemoveUser(string userId)
    {
        userIdToUserMapping.Remove(userId);
    }

}