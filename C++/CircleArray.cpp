#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

bool set(double* A, int N, int tail, int& head, double a)
{
	if (head != tail)
	{
		A[head++] = a;
		if (head == N) head = 0;
		return true;
	}
	return false;
}
bool get(double* A, int N, int& tail, int head, double& a)
{
	if (head == 0 && tail == 0) return false;
	cout << "tail:" << tail << endl;
	a = A[tail];
	if (tail + 1 == N) tail = 0;
	else tail++;
	return true;
}
void show(double* A,int tail,int head,int N) {
	while (tail != head )
	{
		cout << A[tail++] << " " << endl;
		if (tail == N) tail = 0;
	}
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int N = 6;
	double number = 0;
	double A[N] = {88,99, -9, -10, 33, 77};
	int tail = 5, head = 2;
	show(A, tail, head, N);
	cout << endl <<set(A,N, tail, head,10) << endl;
	cout << endl;
	show(A, tail, head, N);
	cout << endl << get(A, N, tail, head, number) << endl;
	cout << endl;
	show(A, tail, head, N);



	system("pause");
}
