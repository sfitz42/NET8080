using Intel8080.Emulator;

namespace Intel8080.TestRoms;

class Program
{
    static void Main(string[] args)
    {
        var memory = new MainMemory(0x10000);
        var cpu = new CPU(memory);

        var testSuite = new TestSuite(cpu, memory);

        testSuite.RunTests();
    }
}