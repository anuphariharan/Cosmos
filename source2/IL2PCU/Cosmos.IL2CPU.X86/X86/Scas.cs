﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.IL2CPU.X86
{
    [OpCode("scas")]
    public class Scas: InstructionWithSize, IInstructionWithPrefix
    {
        public static void InitializeEncodingData(Instruction.InstructionData aData)
        {
        }

        public InstructionPrefixes Prefixes
        {
            get;
            set;
        }

        public override void WriteText(Cosmos.IL2CPU.Assembler aAssembler, System.IO.TextWriter aOutput)
        {
            if ((Prefixes & InstructionPrefixes.RepeatTillNotEqual) != 0)
            {
                aOutput.Write("repne ");
            }
            switch (Size)
            {
                case 32:
                    aOutput.Write("scasd");
                    return;
                case 16:
                    aOutput.Write("scasw");
                    return;
                case 8:
                    aOutput.Write("scasb");
                    return;
                default: throw new Exception("Size not supported!");
            }
        }
    }
}
