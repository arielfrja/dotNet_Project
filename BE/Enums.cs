using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum UserSituation
    {
        EXIST,
        CLOSED
    }
    public enum BranchSituation
    {
        EXIST,
        CLOSED
    }
    public enum DishSituation
    {
        EXIST,
        REMOVED

    }
    public enum OrderSituation
    {
        ORDERED,
        SENT,
        CANCEL
    }
    public enum Kashrut
    {
        LOW,
        MEDIUM,
        HIGH
    }
    public enum OrderedDish_Situation
    {
        FINISH,
        IN_PROGRESS,
        CANCELED
    }
    public enum Time
    {
        HOUR,
        DAY,
        MONTH
    }
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
