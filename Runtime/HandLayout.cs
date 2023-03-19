using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Scripting;
using UnityEngine.InputSystem;

[Preserve]
[InputControlLayout(displayName = "YYSX LHand")]
public class HandLeftLayout : InputDevice
{
    [Preserve]
    [InputControl] //必须要加，否则报错
    public ButtonControl istracked { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone0 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone1 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone2 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone3 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone4 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone5 { get; private set; }
    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone6 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone7 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone8 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone9 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone10 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone11 { get; private set; }
    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone12 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone13 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone14 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone15 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone16 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone17 { get; private set; }
    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone18 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone19 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone20 { get; private set; }


    protected override void FinishSetup()
    {
        base.FinishSetup();
        istracked = GetChildControl<ButtonControl>("istracked");
        bone0 = GetChildControl<BoneControl>("bone0");
        bone1 = GetChildControl<BoneControl>("bone1");
        bone2 = GetChildControl<BoneControl>("bone2");
        bone3 = GetChildControl<BoneControl>("bone3");
        bone4 = GetChildControl<BoneControl>("bone4");
        bone5 = GetChildControl<BoneControl>("bone5");
        bone6 = GetChildControl<BoneControl>("bone6");
        bone7 = GetChildControl<BoneControl>("bone7");
        bone8 = GetChildControl<BoneControl>("bone8");
        bone9 = GetChildControl<BoneControl>("bone9");
        bone10 = GetChildControl<BoneControl>("bone10");
        bone11 = GetChildControl<BoneControl>("bone11");
        bone12 = GetChildControl<BoneControl>("bone12");
        bone13 = GetChildControl<BoneControl>("bone13");
        bone14 = GetChildControl<BoneControl>("bone14");
        bone15 = GetChildControl<BoneControl>("bone15");
        bone16 = GetChildControl<BoneControl>("bone16");
        bone17 = GetChildControl<BoneControl>("bone17");
        bone18 = GetChildControl<BoneControl>("bone18");
        bone19 = GetChildControl<BoneControl>("bone19");
        bone20 = GetChildControl<BoneControl>("bone20");
    }
}



//[Preserve]
//[InputControlLayout(displayName = "YYSX RHand")]
//public class HandRightLayout : HandLayout
//{
//}

[Preserve]
[InputControlLayout(displayName = "YYSX RHand")]
public class HandRightLayout : InputDevice
{
    [Preserve]
    [InputControl] //必须要加，否则报错
    public ButtonControl istracked { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone0 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone1 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone2 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone3 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone4 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone5 { get; private set; }
    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone6 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone7 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone8 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone9 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone10 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone11 { get; private set; }
    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone12 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone13 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone14 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone15 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone16 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone17 { get; private set; }
    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone18 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone19 { get; private set; }

    [Preserve]
    [InputControl] //必须要加，否则报错
    public BoneControl bone20 { get; private set; }


    protected override void FinishSetup()
    {
        base.FinishSetup();
        istracked = GetChildControl<ButtonControl>("istracked");
        bone0 = GetChildControl<BoneControl>("bone0");
        bone1 = GetChildControl<BoneControl>("bone1");
        bone2 = GetChildControl<BoneControl>("bone2");
        bone3 = GetChildControl<BoneControl>("bone3");
        bone4 = GetChildControl<BoneControl>("bone4");
        bone5 = GetChildControl<BoneControl>("bone5");
        bone6 = GetChildControl<BoneControl>("bone6");
        bone7 = GetChildControl<BoneControl>("bone7");
        bone8 = GetChildControl<BoneControl>("bone8");
        bone9 = GetChildControl<BoneControl>("bone9");
        bone10 = GetChildControl<BoneControl>("bone10");
        bone11 = GetChildControl<BoneControl>("bone11");
        bone12 = GetChildControl<BoneControl>("bone12");
        bone13 = GetChildControl<BoneControl>("bone13");
        bone14 = GetChildControl<BoneControl>("bone14");
        bone15 = GetChildControl<BoneControl>("bone15");
        bone16 = GetChildControl<BoneControl>("bone16");
        bone17 = GetChildControl<BoneControl>("bone17");
        bone18 = GetChildControl<BoneControl>("bone18");
        bone19 = GetChildControl<BoneControl>("bone19");
        bone20 = GetChildControl<BoneControl>("bone20");
    }
}