# ParallelArraySum

## Project Description

The **ParallelArraySum** project demonstrates various methods of task parallelization when calculating the sum of elements in an integer array. The project includes three implementations:
1. Sequential computation.
2. Parallel computation using `Thread` and `List` classes.
3. Parallel computation using LINQ.

## Project Goal

The goal of the project is to apply different methods of task parallelization and evaluate the optimal implementation based on execution time.

## Environment

Computer and operating system specifications:

- Processor: Intel Core i5
- RAM: 16 GB
- OS: Windows 10 Pro 64-bit

## Benchmark Results

| Number of Elements   | Sequential Computation (ms) | Parallel Computation (Thread/List) (ms) | Parallel Computation (LINQ) (ms) |
|----------------------|-----------------------------|-----------------------------------------|----------------------------------|
| 100,000              | 0.01                       | 309.00                                   | 329.00                            |
| 1,000,000            | 1.00                       | 115.00                                   | 77.00                            |
| 10,000,000           | 60.00                       | 177.00                                   | 153.00                            |

## How to Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/PiterPoker/ParallelArraySum

## How to Run the Project

### Using PowerShell

1. Clone the repository:
   ```bash
   git clone https://github.com/PiterPoker/ParallelArraySum
   ```

2. Navigate to the project directory:
   ```bash
   cd ParallelArraySum
   ```

3. Build the project:
   ```powershell
   dotnet build
   ```

4. Run the project:
   ```powershell
   dotnet run
   ```
