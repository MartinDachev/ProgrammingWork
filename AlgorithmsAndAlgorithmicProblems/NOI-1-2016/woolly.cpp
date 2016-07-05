#include <iostream>
#include <vector>
#include <bitset>
#include <stack>
using namespace std;

vector<int> v;
vector<unsigned long long> r;
int k = -1;
 string output(63, '0');

void comb(unsigned long long a, unsigned long long b, int k)
{
    //cout<<"k = "<<k<<endl;
    if(k <= -1)
    {
        r.push_back(a+b);
        //cout<<a+b<<endl;
        return;
    }
        //cout<<"a="<<a<<", b="<<b<<endl;
        //cout<<"v[k]"<<v[k]<<endl;
    comb(a , b, k - 1);

    if(v[k] >= 100)
    {
        //cout<<"1     1"<<endl;
       comb(a, (b |= (unsigned long long)(1)<<(v[k] - 100)), k - 1);
    }
    else
    {
        //cout<<"2     2"<<endl;
        comb((a |= (unsigned long long)(1)<<(v[k])), b, k - 1);
    }
    return;
}

int main()
{
    unsigned long long a = 0, b = 0;
    string s1, s2;
    cin>>s1;
    cin>>s2;
    int l = s1.length() - 1;
    for(int i = s1.length(); i >= 0; --i)
    {
        //a = (s1[i] == '1') ? (a + (1<<i))) : a;
        if(s1[i] == '1')
        {
            a |= ((unsigned long long)(1)<<(l - i));
        }
        //cout<<a<<endl;
        if(s1[i] == '?')
        {
            v.push_back(l-i);
            ++k;
        }
    }
    l = s2.length() - 1;
    for(int i = s2.length(); i >= 0; --i)
    {
        if(s2[i] == '1')
        {
            b |= ((unsigned long long)(1)<<(l - i));
        }
        if(s2[i] == '?')
        {
            v.push_back(l-i + 100);
            ++k;
        }
    }
    /*for(int i = 0; i<v.size(); ++i)
    {
        //cout<<v[i];
    }*/
    //cout<<a<<endl<<b<<endl;
    if(v.empty())
    {stack<int> s;
    a = a + b;
        if(a==0)
        {
            cout<<0<<endl;
            return 0;
        }
        while(a!=0)
        {
            s.push(a&1);
            a >>= 1;
        }
        while(!s.empty())
        {
            cout<<s.top();
            s.pop();
        }
        cout<<endl;
         return 0;}
    comb(a, b, k);
    //cout<<r.size()<<endl;
    for(int i = 63; i >= 0; --i)
    {
        bool t = (r[0] & ((unsigned long long)(1))<<i) != 0;
        //if(i==60)cout<<r[0]<<endl;
        for(int k = 1; k < r.size(); ++k)
        {
            if(i == 60)
            {
                //cout<<r[k]<<endl;
            }
            if(((r[k] & ((unsigned long long)(1))<<i) == 0) == (t))
            {
                output[i] = '?';
            }
        }
        if(output[i] == '0')
        {
            output[i] = t != 0 ? '1' : '0';
        }
    }
    bool p = false;
    int i = output.size() - 1;
    while(output[i] == '0')
    {
        --i;
    }
    for(; i >= 0; --i)
    {
             cout<<output[i];
    }
    cout<<endl;
    return 0;
}
