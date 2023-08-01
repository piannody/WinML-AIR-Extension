﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.AI.MachineLearning;

namespace MLANELib.WinML {
    public class SqueezeNetModel : IMachineLearningModel {
        private readonly List<string> _labels = new List<string>();
        public LearningModel LearningModel { get; set; }
        public LearningModelSession Session { get; set; }
        public LearningModelBinding Binding { get; set; }

        private const string LabelsJson = "{\"0\": \"tench, Tinca tinca\",\"1\": \"goldfish, Carassius auratus\",\"2\": \"great white shark, white shark, man-eater, man-eating shark, Carcharodon carcharias\",\"3\": \"tiger shark, Galeocerdo cuvieri\",\"4\": \"hammerhead, hammerhead shark\",\"5\": \"electric ray, crampfish, numbfish, torpedo\",\"6\": \"stingray\",\"7\": \"cock\",\"8\": \"hen\",\"9\": \"ostrich, Struthio camelus\",\"10\": \"brambling, Fringilla montifringilla\",\"11\": \"goldfinch, Carduelis carduelis\",\"12\": \"house finch, linnet, Carpodacus mexicanus\",\"13\": \"junco, snowbird\",\"14\": \"indigo bunting, indigo finch, indigo bird, Passerina cyanea\",\"15\": \"robin, American robin, Turdus migratorius\",\"16\": \"bulbul\",\"17\": \"jay\",\"18\": \"magpie\",\"19\": \"chickadee\",\"20\": \"water ouzel, dipper\",\"21\": \"kite\",\"22\": \"bald eagle, American eagle, Haliaeetus leucocephalus\",\"23\": \"vulture\",\"24\": \"great grey owl, great gray owl, Strix nebulosa\",\"25\": \"European fire salamander, Salamandra salamandra\",\"26\": \"common newt, Triturus vulgaris\",\"27\": \"eft\",\"28\": \"spotted salamander, Ambystoma maculatum\",\"29\": \"axolotl, mud puppy, Ambystoma mexicanum\",\"30\": \"bullfrog, Rana catesbeiana\",\"31\": \"tree frog, tree-frog\",\"32\": \"tailed frog, bell toad, ribbed toad, tailed toad, Ascaphus trui\",\"33\": \"loggerhead, loggerhead turtle, Caretta caretta\",\"34\": \"leatherback turtle, leatherback, leathery turtle, Dermochelys coriacea\",\"35\": \"mud turtle\",\"36\": \"terrapin\",\"37\": \"box turtle, box tortoise\",\"38\": \"banded gecko\",\"39\": \"common iguana, iguana, Iguana iguana\",\"40\": \"American chameleon, anole, Anolis carolinensis\",\"41\": \"whiptail, whiptail lizard\",\"42\": \"agama\",\"43\": \"frilled lizard, Chlamydosaurus kingi\",\"44\": \"alligator lizard\",\"45\": \"Gila monster, Heloderma suspectum\",\"46\": \"green lizard, Lacerta viridis\",\"47\": \"African chameleon, Chamaeleo chamaeleon\",\"48\": \"Komodo dragon, Komodo lizard, dragon lizard, giant lizard, Varanus komodoensis\",\"49\": \"African crocodile, Nile crocodile, Crocodylus niloticus\",\"50\": \"American alligator, Alligator mississipiensis\",\"51\": \"triceratops\",\"52\": \"thunder snake, worm snake, Carphophis amoenus\",\"53\": \"ringneck snake, ring-necked snake, ring snake\",\"54\": \"hognose snake, puff adder, sand viper\",\"55\": \"green snake, grass snake\",\"56\": \"king snake, kingsnake\",\"57\": \"garter snake, grass snake\",\"58\": \"water snake\",\"59\": \"vine snake\",\"60\": \"night snake, Hypsiglena torquata\",\"61\": \"boa constrictor, Constrictor constrictor\",\"62\": \"rock python, rock snake, Python sebae\",\"63\": \"Indian cobra, Naja naja\",\"64\": \"green mamba\",\"65\": \"sea snake\",\"66\": \"horned viper, cerastes, sand viper, horned asp, Cerastes cornutus\",\"67\": \"diamondback, diamondback rattlesnake, Crotalus adamanteus\",\"68\": \"sidewinder, horned rattlesnake, Crotalus cerastes\",\"69\": \"trilobite\",\"70\": \"harvestman, daddy longlegs, Phalangium opilio\",\"71\": \"scorpion\",\"72\": \"black and gold garden spider, Argiope aurantia\",\"73\": \"barn spider, Araneus cavaticus\",\"74\": \"garden spider, Aranea diademata\",\"75\": \"black widow, Latrodectus mactans\",\"76\": \"tarantula\",\"77\": \"wolf spider, hunting spider\",\"78\": \"tick\",\"79\": \"centipede\",\"80\": \"black grouse\",\"81\": \"ptarmigan\",\"82\": \"ruffed grouse, partridge, Bonasa umbellus\",\"83\": \"prairie chicken, prairie grouse, prairie fowl\",\"84\": \"peacock\",\"85\": \"quail\",\"86\": \"partridge\",\"87\": \"African grey, African gray, Psittacus erithacus\",\"88\": \"macaw\",\"89\": \"sulphur-crested cockatoo, Kakatoe galerita, Cacatua galerita\",\"90\": \"lorikeet\",\"91\": \"coucal\",\"92\": \"bee eater\",\"93\": \"hornbill\",\"94\": \"hummingbird\",\"95\": \"jacamar\",\"96\": \"toucan\",\"97\": \"drake\",\"98\": \"red-breasted merganser, Mergus serrator\",\"99\": \"goose\",\"100\": \"black swan, Cygnus atratus\",\"101\": \"tusker\",\"102\": \"echidna, spiny anteater, anteater\",\"103\": \"platypus, duckbill, duckbilled platypus, duck-billed platypus, Ornithorhynchus anatinus\",\"104\": \"wallaby, brush kangaroo\",\"105\": \"koala, koala bear, kangaroo bear, native bear, Phascolarctos cinereus\",\"106\": \"wombat\",\"107\": \"jellyfish\",\"108\": \"sea anemone, anemone\",\"109\": \"brain coral\",\"110\": \"flatworm, platyhelminth\",\"111\": \"nematode, nematode worm, roundworm\",\"112\": \"conch\",\"113\": \"snail\",\"114\": \"slug\",\"115\": \"sea slug, nudibranch\",\"116\": \"chiton, coat-of-mail shell, sea cradle, polyplacophore\",\"117\": \"chambered nautilus, pearly nautilus, nautilus\",\"118\": \"Dungeness crab, Cancer magister\",\"119\": \"rock crab, Cancer irroratus\",\"120\": \"fiddler crab\",\"121\": \"king crab, Alaska crab, Alaskan king crab, Alaska king crab, Paralithodes camtschatica\",\"122\": \"American lobster, Northern lobster, Maine lobster, Homarus americanus\",\"123\": \"spiny lobster, langouste, rock lobster, crawfish, crayfish, sea crawfish\",\"124\": \"crayfish, crawfish, crawdad, crawdaddy\",\"125\": \"hermit crab\",\"126\": \"isopod\",\"127\": \"white stork, Ciconia ciconia\",\"128\": \"black stork, Ciconia nigra\",\"129\": \"spoonbill\",\"130\": \"flamingo\",\"131\": \"little blue heron, Egretta caerulea\",\"132\": \"American egret, great white heron, Egretta albus\",\"133\": \"bittern\",\"134\": \"crane\",\"135\": \"limpkin, Aramus pictus\",\"136\": \"European gallinule, Porphyrio porphyrio\",\"137\": \"American coot, marsh hen, mud hen, water hen, Fulica americana\",\"138\": \"bustard\",\"139\": \"ruddy turnstone, Arenaria interpres\",\"140\": \"red-backed sandpiper, dunlin, Erolia alpina\",\"141\": \"redshank, Tringa totanus\",\"142\": \"dowitcher\",\"143\": \"oystercatcher, oyster catcher\",\"144\": \"pelican\",\"145\": \"king penguin, Aptenodytes patagonica\",\"146\": \"albatross, mollymawk\",\"147\": \"grey whale, gray whale, devilfish, Eschrichtius gibbosus, Eschrichtius robustus\",\"148\": \"killer whale, killer, orca, grampus, sea wolf, Orcinus orca\",\"149\": \"dugong, Dugong dugon\",\"150\": \"sea lion\",\"151\": \"Chihuahua\",\"152\": \"Japanese spaniel\",\"153\": \"Maltese dog, Maltese terrier, Maltese\",\"154\": \"Pekinese, Pekingese, Peke\",\"155\": \"Shih-Tzu\",\"156\": \"Blenheim spaniel\",\"157\": \"papillon\",\"158\": \"toy terrier\",\"159\": \"Rhodesian ridgeback\",\"160\": \"Afghan hound, Afghan\",\"161\": \"basset, basset hound\",\"162\": \"beagle\",\"163\": \"bloodhound, sleuthhound\",\"164\": \"bluetick\",\