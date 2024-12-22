using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoi
{
    public class TemperatureUnit : Unit
    {
        public TemperatureUnit(string name, string symbol) : base(name, symbol) { }

        public override double ConvertTo(Unit unit, double value)
        {
            if (Symbol == "°C" && value < -273.15){ throw new ArgumentException($" {Symbol} không thể bé hơn -273.15...!!!"); }
            if (Symbol == "°F" && value < -459.67){ throw new ArgumentException($" {Symbol} không thể bé hơn -459.67...!!!"); }
            if (Symbol == "°K" && value < 0)      { throw new ArgumentException($" {Symbol} không thể bé hơn 0...!!!"); }
            TemperatureUnit a = (TemperatureUnit)unit;
            if (Symbol == a.Symbol) { return value; }
            // Chọn °C làm gốc
            double valueInCelsius;
            if (Symbol == "°C")         {valueInCelsius = value; }
            else if (Symbol == "°F")    { valueInCelsius = (value - 32) * 5 / 9; }
            else if (Symbol == "°K")    { valueInCelsius = value - 273.15; }
            else if (Symbol == "°Ra")   { valueInCelsius = (value - 491.67) * 5 / 9; }
            else if (Symbol == "°De")   { valueInCelsius = 100 - value * 2 / 3; }
            else { throw new ArgumentException($"Conversion from {Symbol} is not supported."); }

            // Chuyển đổi từ °C sang đơn vị khác
            if (a.Symbol == "°C")       { return valueInCelsius; }
            else if (a.Symbol == "°F")  { return (valueInCelsius * 9 / 5) + 32; }
            else if (a.Symbol == "°K")  { return valueInCelsius + 273.15; }
            else if (a.Symbol == "°Ra") { return (valueInCelsius + 273.15) * 9 / 5; }
            else if (a.Symbol == "°De") { return (100 - valueInCelsius) * 3 / 2; }
            else { throw new ArgumentException("Không thể chuyển đổi giữa các đơn vị không phải nhiệt độ."); }
        }
    }
}