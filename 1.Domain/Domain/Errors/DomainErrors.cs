using Domain.Shared;

namespace Domain.Errors;

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
            "LastName.TooLong",
            "FirstName name is too long");
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

        public static readonly Error TooLong = new(
            "MovieDurationInMinutes.TooLong",
            "MovieDurationInMinutes is too long");
    }
}