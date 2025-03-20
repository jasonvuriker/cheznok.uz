﻿namespace cheznok.uz.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string username)
        :base($"User not found with username: {username}")
    {
    }
}
