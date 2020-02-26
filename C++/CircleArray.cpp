#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

void set(double* A, int N, int& flag, int tail, int& head, double a)
{
	if (flag == -2) return;
	A[head++] = a;
	if (head == N) head = 0;
	flag=(head == tail)?-2:0;
}

void get(double* A, int N, int& flag, int& tail, int head, double& a)
{

	if (flag == -1)return;
	a = A[tail++];
	if (tail == N)tail = 0;
	flag = (tail == head) ? -1 : 0;

}
void show(double* A, int N, int flag, int tail,int head) {
	if (flag == -1) return;
	if (flag==0)
		while (tail != head )
		{
			cout << A[tail++] << "\t";
			if (tail == N) tail = 0;
		}
	else
		do 
		{
			cout << A[tail++] << "\t";
			if (tail == N) tail = 0;
		} while (tail != head);
		cout << endl;
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int N = 6;
	double number = 0;
	int flag = 0;
	int tail = 4, head = 2;

	tail = 4, head = 4;
	double C[N] = { 33, 44, 0, 0, 11, 22 };
	flag = -1;
	//(-2)-полный,
    //(-1)-пустой,
	//(0) -полный
	cout << "1 часть!================================" << endl;
	show(C, N, flag, tail, head);
	cout << "flag:" << flag;
	cout << " head:" << head;
	cout << " tail:" << tail << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	//get(C, N, flag, tail, head, number);
	cout << "2 часть!================================" << endl;
	set(C, N, flag, tail, head, 11);
	set(C, N, flag, tail, head, 22);
	set(C, N, flag, tail, head, 33);
	set(C, N, flag, tail, head, 44);
	set(C, N, flag, tail, head, 55);
	set(C, N, flag, tail, head, 66);
	set(C, N, flag, tail, head, 77);
	cout << "flag:" << flag;
	cout << " head:" << head;
	cout << " tail:" << tail << endl;
	cout << "3 часть!================================" << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	get(C, N, flag, tail, head, number);
	cout << "Number: " << number << endl;
	show(C, N, flag, tail, head);
	cout << "flag:" << flag;
	cout << " head:" << head;
	cout << " tail:" << tail << endl;
	system("pause");
}
