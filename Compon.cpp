#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

class Minesweeper {
public:
    Minesweeper(int width, int height, int num_mines) : width(width), height(height), num_mines(num_mines) {
        board = vector<vector<char>>(height, vector<char>(width, '-'));

        srand(time(NULL));
        int mines_placed = 0;
        while (mines_placed < num_mines) {
            int x = rand() % width;
            int y = rand() % height;
            if (board[y][x] != '*') {
                board[y][x] = '*';
                mines_placed++;
            }
        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                if (board[y][x] == '*') {
                    continue;
                }
                int count = 0;
                for (int dy = -1; dy <= 1; dy++) {
                    for (int dx = -1; dx <= 1; dx++) {
                        if (dx == 0 && dy == 0) {
                            continue;
                        }
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx >= 0 && nx < width && ny >= 0 && ny < height && board[ny][nx] == '*') {
                            count++;
                        }
                    }
                }
                board[y][x] = count + '0';
            }
        }
    }

    void play() {
        int num_uncovered = 0;
        while (num_uncovered < width * height - num_mines) {

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    cout << board[y][x] << " ";
                }
                cout << endl;
            }

            int x, y;cout << "Enter coordinates (x y): ";
            cin >> x >> y;

            if (x < 0 || x >= width || y < 0 || y >= height) {cout << "Invalid coordinates!" << endl;
                continue;}


            board[y][x] = get_cell_value(x, y);
            num_uncovered++;

            if (board[y][x] == '*') {
                cout << "Game over! You hit a mine." << endl;
                return;
            }
        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                cout << board[y][x] << " ";
            }
            cout << endl;
        }

    }

private:
    int width;
    int height;
    int num_mines;
    vector<vector<char>> board;

    char get_cell_value(int x, int y) {
        if (board[y][x] == '*') {
            return '*';
        }
        int count = 0;
        if (y > 0) {
            if (x > 0 && board[y - 1][x - 1] == '*') {
                count++;
            }
            if (board[y - 1][x] == '*') {
                count++;
            }
            if (x < width - 1 && board[y - 1][x + 1] == '*') {
                count++;
            }
        }
        if (y < height - 1) {
            if (x > 0 && board[y + 1][x - 1] == '*') {
                count++;
            }
            if (board[y + 1][x] == '*') {
                count++;
            }
            if (x < width - 1 && board[y + 1][x + 1] == '*') {
                count++;
            }
        }
        if (x > 0 && board[y][x - 1] == '*') {
            count++;
        }
        if (x < width - 1 && board[y][x + 1] == '*') {
            count++;
        }
        return count + '0';
    }
};

int main() {
    Minesweeper game(10, 10, 10);
    game.play();
    return 0;
}
