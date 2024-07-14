using Domain.Shared;

namespace Domain.Errors;

/// <summary>
/// Represents a domain error which holds all the different domain errors
/// </summary>
public static class DomainErrors
{
    public static class Email
    {
        public static readonly Error Empty = new(
            "Email.Empty",
            "Email is empty");

        public static readonly Error InvalidFormat = new(
            "Email.InvalidFormat",
            "Email format is invalid");
    }

    public static class FirstName
    {
        public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name is empty");

        public static readonly Error TooLong = new(
            "FirstName.TooLong",
            "First name is too long");
    }

    public static class CinemaName
    {
        public static readonly Error Empty = new(
            "CinemaName.Empty",
            "Cinema name is empty");

        public static readonly Error TooLong = new(
            "CinemaName.TooLong",
            "Cinema name is too long");
    }

    public static class Address
    {
        public static readonly Error Empty = new(
            "Address.Empty",
            "Address is empty");

        public static readonly Error TooLong = new(
            "Address.TooLong",
            "Address is too long");
    }

    public static class CityName
    {
        public static readonly Error Empty = new(
            "CityName.Empty",
            "City name is empty");

        public static readonly Error TooLong = new(
            "CityName.TooLong",
            "City name is too long");
    }

    public static class StateName
    {
        public static readonly Error Empty = new(
            "StateName.Empty",
            "State name is empty");

        public static readonly Error TooLong = new(
            "StateName.TooLong",
            "State name is too long");
    }

    public static class LastName
    {
        public static readonly Error Empty = new(
            "LastName.Empty",
            "Last name is empty");

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "Last name is too long");
    }

    public static class Age
    {
        public static readonly Error Zero = new(
            "Age.Zero",
            "Age is Zero");

        public static readonly Error TooYoung = new(
            "Age.TooYoung",
            "Age is too young");

        public static readonly Error TooOld = new(
            "Age.TooOld",
            "Age is too old");
    }

    public static class Title
    {
        public static readonly Error Empty = new(
            "Title.Empty",
            "Title is empty");

        public static readonly Error TooLong = new(
            "Title.TooLong",
            "Title is too long");
    }

    public static class Score
    {
        public static readonly Error Negative = new(
            "Score.Negative",
            "Score is negative");

        public static readonly Error TooHigh = new(
            "Score.TooHigh",
            "Score is too high");
    }

    public static class Plot
    {
        public static readonly Error Empty = new(
            "Plot.Empty",
            "Plot is empty");

        public static readonly Error TooLong = new(
            "Plot.TooLong",
            "Plot is too long");
    }

    public static class MovieDurationInMinutes
    {
        public static readonly Error Negative = new(
            "MovieDurationInMinutes.Negative",
            "MovieDurationInMinutes is negative");

        public static readonly Error Zero = new(
           "MovieDurationInMinutes.Zero",
           "MovieDurationInMinutes is Zero");

        public static readonly Error TooLong = new(
            "MovieDurationInMinutes.TooLong",
            "MovieDurationInMinutes is too long");
    }


    public static class TrailerDurationInMinutes
    {
        public static readonly Error Negative = new(
            "TrailerDurationInMinutes.Negative",
            "TrailerDurationInMinutes is negative");

        public static readonly Error Zero = new(
           "TrailerDurationInMinutes.Zero",
           "TrailerDurationInMinutes is Zero");

        public static readonly Error TooLong = new(
            "TrailerDurationInMinutes.TooLong",
            "TrailerDurationInMinutes is too long");
    }
}