#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <cmath>

using namespace std;

int n;
char p='+';
char m='-';
void turnon(int n, char c)
{
    if(n <= 0)
    {
        return;
    }
    turnon(n-1, p);
    turnon(n-2, m);
    cout<<c<<n<<endl;
}

int main()
{
    cin>>n;
    turnon(n, p);
	return 0;
}
