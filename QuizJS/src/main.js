// TODO 1

const statement = document.getElementById("statement");

const optionButtons = document.querySelectorAll('#options *');

const explanation = document.getElementById("explanation");

//Test su console per vedere il corretto funzionamento
console.log(statement);
console.log(optionButtons);
console.log(explanation);

//TODO 2

const fact = {
    dichiarazione: "In JavaScript il risultato dell'espressione `2 + '2'` rilascia come risultato 22?",
    risposta: true,
    spiegazione: "In JavaScript, la somma tra più tipi è possibile. In questo caso avviene una concatenazone del `2` numero e `2` stringa, risultando effettivamente in 22 come risultato."
}

console.log(fact);

//TODO 3
// could use statement.textContent
statement.innerHTML = fact.dichiarazione;

// TODO 4

function disable(button) {
    button.setAttribute("disabled", "");
}

function enable(button) {
    button.setAttribute("disabled");
}

// TODO 5

function isCorrect(guess) {
    const risposta = guess === "true"; //boolean = string === string
    return risposta === fact.risposta; //boolean === boolean
}

// TODO 6

for (let i = 0; i < optionButtons.length; i++) {
    optionButtons[i].addEventListener('click', (e) => {
        explanation.innerHTML = fact.spiegazione;
        
        const userGuess = e.target.value;
        const risposta = isCorrect(userGuess);
        
        // TODO 8 (da migliorare)

        for (let j = 0; j < optionButtons.length; j++) {
            if (e.target == optionButtons[0]) {
                optionButtons[0].classList.add("correct")
            }
            else
            {
                optionButtons[1].classList.add("incorrect")
            }
        }

        console.log(risposta)

        //TODO 7

        for (let j = 0; j < optionButtons.length; j++) {
            disable(optionButtons[j]);
        }
    });
}