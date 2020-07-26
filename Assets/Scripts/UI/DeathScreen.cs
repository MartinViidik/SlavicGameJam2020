using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour {

    [SerializeField] private TMP_Text jap;

    [SerializeField] private TMP_Text eng;

    [SerializeField] private string[] jap_proverb;

    [SerializeField] private string[] eng_proverb;

    [SerializeField] private GameObject ingameUI;

    private readonly List<Proverb> proverbs = new List<Proverb> {
        new Proverb {ProverbText = "悪妻は百年の不作。", Translation = "(A bad wife spells a hundred years of bad harvest.)"},
        new Proverb {ProverbText = "残り物には福がある。", Translation = "(Luck exists in the leftovers.)"},
        new Proverb {
            ProverbText = "虎穴に入らずんば虎子を得ず。",
            Translation = "(If you do not enter the tiger's cave, you will not catch its cub.)"
        },
        new Proverb {ProverbText = "花鳥風月", Translation = "(Flower, Bird, Wind, Moon)"},
        new Proverb {ProverbText = "起死回生", Translation = "(Wake from death and return to life)"},
        new Proverb {ProverbText = "自業自得", Translation = "(One's Act, One's profit/Advantage.)"},
        new Proverb {ProverbText = "瓜田李下", Translation = "(Melon field, under a plum tree)"},
        new Proverb {ProverbText = "晴天の霹靂", Translation = "(Thunderclap from a clear sky.)"},
        new Proverb {ProverbText = "猿も木から落ちる。", Translation = "(Even monkeys fall from trees.)"},
        new Proverb {ProverbText = "蓼食う虫も好き好き", Translation = "(There are even bugs that eat knotweed.)"},
        new Proverb {ProverbText = "井の中の蛙大海を知らず。", Translation = "(A frog in a well does not know the great sea.)"},
        new Proverb {ProverbText = "蛙の子は蛙。", Translation = "(Child of a frog is a frog.)"},
        new Proverb {ProverbText = "鳶が鷹を産む。", Translation = "(A kite breeding a hawk.)"},
        new Proverb {ProverbText = "覆水盆に帰らず。", Translation = "(Spilt water will not return to the tray.)"},
        new Proverb {
            ProverbText = "二兎を追う者は一兎をも得ず。", Translation = "(One who chases after two hares won't catch even one.)"
        },
        new Proverb {ProverbText = "継続は力なり。", Translation = "(Continuance (also) is power/strength.)"},
        new Proverb {
            ProverbText = "門前の小僧習わぬ経を読む。",
            Translation = "(An apprentice near a temple will recite the scriptures untaught.)"
        },
        new Proverb {ProverbText = "知らぬが仏", Translation = "(Not knowing is Buddha.)"},
        new Proverb {ProverbText = "見ぬが花", Translation = "(Not seeing is a flower.)"},
        new Proverb {ProverbText = "猫に小判", Translation = "(gold coins to a cat.)"},
        new Proverb {ProverbText = "猫に鰹節", Translation = "(fish to a cat.)"},
        new Proverb {ProverbText = "七転び八起き", Translation = "(stumbling seven times but recovering eight.)"},
        new Proverb {ProverbText = "三日坊主", Translation = "(a monk for (just) three days.)"},
        new Proverb {
            ProverbText = "案ずるより産むが易し。", Translation = "(Giving birth to a baby is easier than worrying about it.)"
        },
        new Proverb {ProverbText = "馬鹿は死ななきゃ治らない。", Translation = "(Unless an idiot dies, he won't be cured.)"},
        new Proverb {ProverbText = "出る杭は打たれる。", Translation = "(The stake that sticks out gets hammered down.)"},
        new Proverb {
            ProverbText = "挨拶は時の氏神。", Translation = "(A greeting is the local deity who turns up providentially.)"
        },
        new Proverb {
            ProverbText = "秋茄子は嫁に食わすな。", Translation = "(Don't let your daughter-in-law eat your autumn eggplants.)"
        },
        new Proverb {ProverbText = "花よりだんご", Translation = "(dumplings over flowers)"},
        new Proverb {ProverbText = "水に流す", Translation = "(let flow in the water)"},
        new Proverb {ProverbText = "雨降って地固まる", Translation = "(after the rain, earth hardens)"},
        new Proverb {ProverbText = "油を売る", Translation = "(to sell oil)"},
        new Proverb {ProverbText = "竜頭蛇尾", Translation = "(dragon, head, snake, tail)"},
        new Proverb {ProverbText = "晴耕雨読", Translation = "(clear sky, cultivate, rainy, reading)"},
        new Proverb {ProverbText = "四面楚歌", Translation = "(Chu songs on all sides)"},
        new Proverb {ProverbText = "十人十色", Translation = "(ten men, ten colors)"},
        new Proverb {ProverbText = "三日坊主", Translation = "(3 day monk.)"},
        new Proverb {ProverbText = "大同小異", Translation = "(big similarity, small difference)"},
        new Proverb {ProverbText = "一石二鳥", Translation = "(one stone, two birds)"},
        new Proverb {ProverbText = "雲散霧消", Translation = "(scattered clouds, disappearing mist)"},
        new Proverb {ProverbText = "我田引水", Translation = "(pulling water to my own rice paddy)"},
    };

    private void OnEnable() {
        // int RNG = Random.Range(0, jap_proverb.Length);
        // jap.text = jap_proverb[RNG];
        // eng.text = eng_proverb[RNG];
        var proverb = proverbs[Random.Range(0, proverbs.Count)];
        jap.text = proverb.ProverbText;
        eng.text = proverb.Translation;
        ingameUI.SetActive(false);
    }

    private class Proverb {

        public string ProverbText { get; set; }
        public string Translation { get; set; }

    }

}