using general.win.condition.collect;
using general.win.condition.single;

namespace general.win.condition.factory
{
    public class WinCheckOne : WinCheckBase
    {
        public override WinConditionBase Create()
        {
            var winCheck = new WinConditionMain();
            winCheck
                .SetNext(new WinConditionTie());

            return winCheck;
        }
    }
}