﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller01;

public class Time
{   
    //Campos - Atributos
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    //Métodos Constructores
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    public Time(int hour)
    {
        Hour = ValidateHour(hour);
    }

    public Time(int hour, int minute)
    {
        Hour = ValidateHour(hour);
        Minute = ValidateMinute(minute);
    }

    public Time(int hour, int minute, int second)
    {
        Hour = ValidateHour(hour);
        Minute = ValidateMinute(minute);
        Second = ValidateSecond(second);
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = ValidateHour(hour);
        Minute = ValidateMinute(minute);
        Second = ValidateSecond(second);
        Millisecond = ValidateMillisecond(millisecond);
    }
    //Propiedades
    public int Hour 
    { 
        get => _hour; 
        set => _hour = ValidateHour(value); 
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }
    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }
    //Métodos Públicos

    public Time Add(Time time)

    {

        int totalMilliseconds = (Hour * 3600000 + Minute * 60000 + Second * 1000 + Millisecond) +

                               (time.Hour * 3600000 + time.Minute * 60000 + time.Second * 1000 + time.Millisecond);

        int newHours = (totalMilliseconds / 3600000);
        if (newHours >= 24)
        {
            newHours = newHours % 24;
        }
        else
        {
            newHours = newHours;
        }

        totalMilliseconds %= 3600000;

        int newMinutes = totalMilliseconds / 60000;
        if (newMinutes >= 60)
        {
            newMinutes = newMinutes % 60;
        }
        else
        {
            newMinutes = newMinutes;
        }

        totalMilliseconds %= 60000;

        int newSeconds = totalMilliseconds / 1000;
        if (newSeconds >= 60)
        {
            newSeconds = newSeconds % 60;
        }
        else
        {
            newSeconds = newSeconds;
        }

        int newMiliseconds = totalMilliseconds % 1000;

        return new Time(newHours, newMinutes, newSeconds, newMiliseconds);

    }

    public bool IsOtherDay(Time time)

    {

        int totalMilliseconds = (Hour * 3600000 + Minute * 60000 + Second * 1000 + Millisecond) +

                               (time.Hour * 3600000 + time.Minute * 60000 + time.Second * 1000 + time.Millisecond);
        int totalHours = totalMilliseconds / 3600000;
        if (totalHours >= 24)
        {
            return true;
        }
        else
        {
            return false;
        }      

    }
    public int ToMinutes()
    {
        return _minute + _hour * 60;
    }

    public int ToSeconds()
    {
        return _second + _minute * 60 + _hour * 3600;
    }

    public override string ToString()
    {
        string tt;
        if (Hour < 12)
        {
            tt = "AM";
        }
        else
        {
            tt = "PM";
        }
        int hour = Hour % 12;
        if (hour == 0)
        {
            hour = 0;
        }
        else
        {
            hour = hour;
        }
        return $"{hour:00}:{_minute:00}:{_second:00}.{_millisecond:000} {tt}";
    }
    //Métodos Privados
    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentException($"The hour: {hour}, not is valid");
        }
        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentException($"The minute: {minute}, not is valid");
        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentException($"The second: {second}, not is valid");
        }
        return second;
    }

    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentException($"The millisecond: {millisecond}, not is valid");
        }
        return millisecond;
    }
}

