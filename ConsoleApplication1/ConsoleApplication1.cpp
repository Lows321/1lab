#include <iostream>
#include <cmath>
#include <vector>
#define _USE_MATH_DEFINES
#include <math.h>


using namespace std;


class Sector {
public:
    // Конструктор класса Sector, инициализирует радиус и центральный угол.
    Sector(double radius = 0, double central_angel = 0) : radius(radius), central_angel(central_angel) {}

    // Изменяет радиус сектора, умножая на заданный коэффициент.
    void resize(double factor) {
        radius *= factor;
    }

    // Вычисляет площадь сектора.
    const double calculateArea() {
        return 0.5 * radius * radius * central_angel;
    }

    // Вычисляет длину дуги сектора.
    const double calculateArcLength() {
        return radius * central_angel;
    }

    // Вычисляет полную окружность круга.
    const double calculateCircumference() {
        return 2 * M_PI * radius;
    }

    // Вычисляет диаметр круга.
    const double calculateDiameter() {
        return 2 * radius;
    }

public:
    double radius;        // Радиус сектора.
    double central_angel; // Центральный угол сектора в радианах.
};

int main() {
    setlocale(LC_ALL, "Russian");
    // Ввод количества секторов
    int numSectors;
    cout << "Введите количество секторов: ";
    cin >> numSectors;

    // Ввод данных о секторах
    vector<Sector> sectors(numSectors);
    for (int i = 0; i < numSectors; ++i) {
        cout << "Введите радиус сектора " << i + 1 << ": ";
        cin >> sectors[i].radius;
        cout << "Введите центральный угол (в радианах) сектора " << i + 1 << ": ";
        cin >> sectors[i].central_angel;
    }

    // Главный цикл программы
    while (true) {
        // Вывод меню
        cout << "\nВыберите операцию:\n1. Увеличить/уменьшить размер сектора\n2. Вычислить площадь сектора\n3. Вычислить длину дуги сектора\n"
            <<"4. Вычислить длину окружности\n5. Вычислить диаметр окружности\n5. Вычислить диаметр окружности\n6. Выход\n";
        // Ввод выбора пользователя
        int choice;
        cout << "Введите номер операции: ";
        cin >> choice;

        if (choice == 6) {
            break;
        }

        // Ввод индекса сектора
        int sectorIndex;
        cout << "Введите индекс сектора (от 0 до " << numSectors - 1 << "): ";
        cin >> sectorIndex;

        if (sectorIndex < 0 || sectorIndex >= numSectors) {
            cout << "Неверный индекс сектора.";
            continue;
        }

        // Выполнение выбранной операции
        switch (choice) {
        case 1: {
            // Увеличение/уменьшение размера сектора
            double factor;
            cout << "Введите коэффициент увеличения/уменьшения: ";
            cin >> factor;
            sectors[sectorIndex].resize(factor);
            cout << "Размер сектора изменен.";
            break;
           
        }
        case 2: {
            // Вычисление площади сектора
            double area = sectors[sectorIndex].calculateArea();
            cout << "Площадь сектора: " << area << endl;
            break;
        }
        case 3: {
            // Вычисление длины дуги сектора
            double arcLength = sectors[sectorIndex].calculateArcLength();
            cout << "Длина дуги сектора: " << arcLength << endl;
            break;
        }
        case 4: {
            // Вычисление длины окружности
            double circumference = sectors[sectorIndex].calculateCircumference();
            cout << "Длина окружности: " << circumference << endl;
            break;
        }
        case 5: {
            // Вычисление диаметра окружности
            double diameter = sectors[sectorIndex].calculateDiameter();
            cout << "Диаметр окружности: " << diameter << endl;
            break;
        }
        case 6: 
            // Вычисление диаметра окружности
            double dia = sectors[sectorIndex].calculateDiameter();
            cout << "Диаметр окружности: " << dia << endl;
            break;
        default:
            cout << "Неверный выбор операции.";
        }
    }

    return 0;
}