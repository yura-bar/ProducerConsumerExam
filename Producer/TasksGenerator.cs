using ModelsDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    internal static class TasksGenerator
    {
        private const string text1 = "Long ago, a pageboy was a knight's assistant. Today, a pageboy is either an employee who runs errands, or it's a bowl-shaped haircut with curled-under ends.";
        private const string text2 = "To gibe is to sneer or heckle, but to jibe is to agree. Funny thing is, though, jibe is an alternate spelling of gibe, so surprise! People get them mixed up.";
        private const string text3 = "Flair is a talent for something, like what the pro-wrestler Nature Boy Ric Flair had back in the day. Flare is on a candle or the shape of bell-bottoms that kids rocked back in the heyday of wrastlin'.";
        private const string text4 = "A paradox is a logical puzzle that seems to contradict itself. No it isn't. Actually, it is. An oxymoron is a figure of speech — words that seem to cancel each other out, like 'working vacation' or 'instant classic.'";
        private const string text5 = "A connotation is the feeling a word invokes. But take note! A denotation is what the word literally says. If these words were on a trip, connotation would be the baggage, and denotation would be the traveler.";
        private const string text6 = "Morbid describes something gruesome, like smallpox or Frankenstein's monster. Moribund refers to the act of dying. Goths love both. What fun!";
        private const string text7 = "Anything objective sticks to the facts, but anything subjective has feelings. Objective and subjective are opposites. Objective: It is raining. Subjective: I love the rain!";
        private const string text8 = "If you're pragmatic, you're practical. You're living in the real world, wearing comfortable shoes. If you're dogmatic, you follow the rules. You're living in the world you want, and acting a little stuck up about it.";

        internal static List<Task> GenerateTasks()
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text1, Status = StatusEnum.Pending.ToString(), ConsumerID = 1 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text2, Status = StatusEnum.Pending.ToString(), ConsumerID = 3 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text3, Status = StatusEnum.Pending.ToString(), ConsumerID = 1 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text4, Status = StatusEnum.Pending.ToString(), ConsumerID = 5 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text5, Status = StatusEnum.Pending.ToString(), ConsumerID = 2 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text6, Status = StatusEnum.Pending.ToString(), ConsumerID = 4 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text7, Status = StatusEnum.Pending.ToString(), ConsumerID = 1 });
            tasks.Add(new Task { CreationTime = DateTime.UtcNow, TaskText = text8, Status = StatusEnum.Pending.ToString(), ConsumerID = 2 });

            return tasks;
        }

    }
}
