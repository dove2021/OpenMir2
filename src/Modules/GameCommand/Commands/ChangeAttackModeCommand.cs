using OpenMir2;
using OpenMir2.Enums;
using SystemModule;
using SystemModule.Actors;
using SystemModule.Enums;

namespace CommandModule.Commands
{
    /// <summary>
    /// 调整当前玩家攻击模式
    /// </summary>
    [Command("AttackMode", "调整当前玩家攻击模式")]
    public class ChangeAttackModeCommand : GameCommand
    {
        [ExecuteCommand]
        public void Execute(IPlayerActor PlayerActor)
        {
            if (PlayerActor.AttatckMode >= AttackMode.HAM_PKATTACK)
            {
                PlayerActor.AttatckMode = AttackMode.HAM_ALL;
            }
            else
            {
                PlayerActor.AttatckMode++;
            }
            switch (PlayerActor.AttatckMode)
            {
                case AttackMode.HAM_ALL:// [攻击模式: 全体攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfAll, MsgColor.Green, MsgType.Hint);
                    break;
                case AttackMode.HAM_PEACE: // [攻击模式: 和平攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfPeaceful, MsgColor.Green, MsgType.Hint);
                    break;
                case AttackMode.HAM_DEAR:// [攻击模式: 和平攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfDear, MsgColor.Green, MsgType.Hint);
                    break;
                case AttackMode.HAM_MASTER:// [攻击模式: 和平攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfMaster, MsgColor.Green, MsgType.Hint);
                    break;
                case AttackMode.HAM_GROUP:// [攻击模式: 编组攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfGroup, MsgColor.Green, MsgType.Hint);
                    break;
                case AttackMode.HAM_GUILD:// [攻击模式: 行会攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfGuild, MsgColor.Green, MsgType.Hint);
                    break;
                case AttackMode.HAM_PKATTACK:// [攻击模式: 红名攻击]
                    PlayerActor.SysMsg(MessageSettings.AttackModeOfRedWhite, MsgColor.Green, MsgType.Hint);
                    break;
            }
            byte nParam = (byte)PlayerActor.AttatckMode;
            PlayerActor.SendDefMessage(Messages.SM_ATTACKMODE, 0, nParam, 0, 0);
        }
    }
}