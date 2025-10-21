# OldPhonePad

A C# program that simulates the behavior of a old-school mobile phone keypad — supporting multi-tap text input, backspace, and send functionality. Input is provided via command-line arguments and converted into readable text.

--

## 📝 Description

**OldPhonePad** is a C# console application that emulates the functionality of old-school mobile phone keypads. Users interact with the system using input strings consisting of keypad characters (`1-9`, `0`, `*`, `#`), similar to how SMS messages were typed on feature phones.

This project includes both the main program and unit tests to validate input handling and output correctness.

### How It Works

- Accepts input as a string of keypad characters: `1234567890*#`
- Each key maps to a set of characters:
  - `2` → `A B C`
  - `3` → `D E F`
  - `4` → `G H I`
  - `5` → `J K L`
  - `6` → `M N O`
  - `7` → `P Q R S`
  - `8` → `T U V`
  - `9` → `W X Y Z`
  - `0` → space (` `)
  - `1` → symbols (`& ' (`)
- Pressing a key multiple times cycles through the characters
- Use a **space** between inputs if two characters are on the same key (e.g., `44 444` → `HI`)
- `*` represents **backspace**
- `#` represents **send** and signals the end of input

###  Features

- Supports input via command-line arguments  
- Handles multi-tap behavior for text input  
- Includes backspace support with `*`  
- Stops processing input at the `#` key (send)  
- Comes with unit tests for various input scenarios  
- Accepts only valid characters: `1 2 3 4 5 6 7 8 9 0 * #`

---

## 💻 Installation

### Requirments
- .NET SDK version 6.0 S or later
- Make (optional, for using `Makefile` commands)

### Steps

1. Clone the repository:
```bash
$ git clone https://github.com/Shivalux/OldPhonePad.git
$ cd OldPhonePad
```
2. Compiles a .NET project and its dependecies into binaries:
```bash
$ make
```
3. The `OldPhonePad.sh` script will be generate for running the program.

## 🧰Makefile Commands

Command | Description|
--------|------------|
`make`, `make all` | Build the project and all dependencies |
`make test` | Run the unit test |
`make clean` | Clean the output of a previous build |
`make fclean` | Remove all bin/ and obj/ directory |
`make re` | clean and rebuild entire project |

## 🚀 Usage

```bash
./OldPhonePad.sh [INPUTS ...]
```
### Noted

• If no input is provided, the program will run using example inputs.


## 🧪Example

### Run the App
#### Command

```bash
$ ./OldPhonePad.sh 33# 227*# "4433555 555666#" "8 88777444666*664#"
```
#### What happens

* Recive input:
`["33#, "227*#", "4433555 555666#", "8 88777444666*664#"]` as arguments
* Convert each to readable text
* Outputs results to the console

#### Output

```bash
OldPhonePad("33#") => output: |E|
OldPhonePad("227*#") => output: |B|
OldPhonePad("4433555 555666#") => output: |HELLO|
OldPhonePad("8 88777444666*664#") => output: |TURING|
```
### Run Tests

#### Command

```bash
$ make test
```

####  Output
```bash
Restore complete (0.3s)
  OldPhonePad succeeded (0.1s) → OldPhonePad/bin/Debug/net9.0/OldPhonePad.dll
  OldPhonePad.Tests succeeded (1.3s) → OldPhonePad.Tests/bin/Debug/net9.0/OldPhonePad.Tests.dll
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.8.2+699d445a1a (64-bit .NET 9.0.10)
[xUnit.net 00:00:00.03]   Discovering: OldPhonePad.Tests
[xUnit.net 00:00:00.06]   Discovered:  OldPhonePad.Tests
[xUnit.net 00:00:00.06]   Starting:    OldPhonePad.Tests
[xUnit.net 00:00:00.10]   Finished:    OldPhonePad.Tests
  OldPhonePad.Tests test succeeded (0.5s)

Test summary: total: 10, failed: 0, succeeded: 10, skipped: 0, duration: 0.5s
```

## 👥 Authors & Acknowledments

Created by @Shivalux

## ⚖️License

This project is licensed under the MIT License.  
See the [LICENSE](LICENSE) file for more information.