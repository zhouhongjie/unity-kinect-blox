#include "Helpers.h"
#include <cmath>
namespace vampBBC{

double Helpers::Round(double number)
{
    return number < 0.0 ? ceil(number - 0.5) : floor(number + 0.5);
}
}