#include <iostream>
#include <cmath>

using namespace std;

struct Point
{
    double x;
    double y;
};

double a, b;
double step = 0.000001;
double EPS = 0.00000001;
Point A, B, C, D, A1, B1, C1, D1;

double Determine(double a, double b, double c, double d)
{
    return a * d - b * c;
}

void Intersect(Point A,Point B,Point C,Point D,Point &X)
{
    double a1, b1, c1, a2, b2, c2, t;
    a1 = Determine(1, B.y, 1, A.y);
    b1 = Determine(B.x, 1, A.x, 1);
    c1 = Determine(A.x, A.y, B.x, B.y);
    a2 = Determine(1, D.y, 1, C.y);
    b2 = Determine(D.x, 1, C.x, 1);
    c2 = Determine(C.x, C.y, D.x, D.y);
    t = Determine(a1, a2, b1, b2);

    if (fabs(t) < EPS) // t == 0
    {
        return;
    }

    X.x=Determine(b1,b2,c1,c2)/t;
    X.y=Determine(c1,c2,a1,a2)/t;
}

double Area(Point a, Point b, Point c)
{
    return (0.5*fabs(a.x*(b.y - c.y) + b.x*(c.y - a.y) + c.x*(a.y - b.y)));
}

Point Rotate(Point p, float angle)
{
    Point r;
    r.x = p.x*cos(angle) - p.y*sin(angle);
    r.y = p.y*cos(angle) + p.x*sin(angle);
    return r;
}

void CalcMaxArea()
{
    double angle = atan2(b, a);
    double maxAngle = 2 * angle + 0.001;
    double maxArea = -1;
    while(angle <= maxAngle)
    {
        angle += step;
        Point M, N, P, Q;
        A1 = Rotate(A, angle);
        B1 = Rotate(B, angle);
        C1 = Rotate(C, angle);
        D1 = Rotate(D, angle);
        Intersect(A1, B1, B, C, M);
        Intersect(B1, C1, B, C, N);
        Intersect(B1, C1, C, D, P);
        Intersect(C1, D1, C, D, Q);
        double area1 = 2 * a * b - b * b;
        double area2 = a * b + 2 * Area(M, B1, N) + 2 * Area(P, C1, Q);
        area1 = max(area1, area2);
        maxArea = max(area1, maxArea);
    }
    cout.precision(3);
    cout<<fixed<<maxArea<<endl;
}

int main()
{
    cin>>a>>b;
    if(a < b)
    {
        double t=a;
        a=b;
        b=t;
    }
    A.x = -a/2;
    A.y = -b/2;
    B.x = a/2;
    B.y = -b/2;
    C.x = a/2;
    C.y = b/2;
    D.x = -a/2;
    D.y = b/2;
    CalcMaxArea();
    return 0;
}
