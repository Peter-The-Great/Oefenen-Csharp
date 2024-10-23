// Array met vragen en antwoorden
const quizData = [
    {
        question: "Wat is de hoofdstad van Nederland?",
        answers: ["Rotterdam", "Amsterdam", "Den Haag", "Utrecht"],
        correct: "Amsterdam"
    },
    {
        question: "Wat is 5 + 3?",
        answers: ["5", "6", "7", "8"],
        correct: "8"
    },
    {
        question: "Wie schreef 'De Donkere Toren' serie?",
        answers: ["J.K. Rowling", "Stephen King", "George R.R. Martin", "Tolkien"],
        correct: "Stephen King"
    }
];

let currentQuestionIndex = 0;
let score = 0;
let answerIsChecked = false;

// Functie om de huidige vraag weer te geven
function loadQuestion() {
    const questionElement = document.getElementById('question');
    const answerContainer = document.getElementById('answer-container');

    // Huidige vraag ophalen
    const currentQuestion = quizData[currentQuestionIndex];

    // Vraag weergeven
    questionElement.textContent = currentQuestion.question;

    // Antwoorden weergeven als knoppen
    answerContainer.innerHTML = ''; // Leeg de oude antwoorden
    currentQuestion.answers.forEach(answer => {
        const button = document.createElement('button');
        button.textContent = answer;
        button.classList.add('answer-btn');
        button.addEventListener('click', () => checkAnswer(answer));
        answerContainer.appendChild(button);
    });
}

// Functie om te controleren of het antwoord correct is
function checkAnswer(selectedAnswer) {
    const currentQuestion = quizData[currentQuestionIndex];
    if (selectedAnswer === currentQuestion.correct && !answerIsChecked) {
        score++;
        answerIsChecked = true;
    }
    document.getElementById('score').textContent = `Score: ${score}`;
    document.getElementById('answer-container').querySelectorAll('button').forEach(button => {
        button.disabled = true;
        if (button.textContent === currentQuestion.correct) {
            button.classList.add('correct');
        } else {
            button.classList.add('incorrect');
        }
    });
    // Zet de knop aan voor de volgende vraag
    document.getElementById('next-btn').disabled = false;
}

// Event om naar de volgende vraag te gaan
function nextQuestion() {
    currentQuestionIndex++;
    
    if (currentQuestionIndex < quizData.length) {
        loadQuestion();
        answerIsChecked = false; // Reset the answer check for the new question
        document.getElementById('next-btn').disabled = true; // Deactiveer de knop tot antwoord
    } else {
        // Einde van de quiz
        document.getElementById('question').textContent = "Je hebt de quiz voltooid!";
        document.getElementById('answer-container').innerHTML = '';
        document.getElementById('next-btn').style.display = 'none';
    }
}

// Pagina laadt automatisch de eerste vraag
window.onload = function() {
    loadQuestion();
    document.getElementById('next-btn').disabled = true; // Deactiveer de volgende knop in het begin
};

// Event listener voor de "volgende vraag" knop
document.getElementById('next-btn').addEventListener('click', nextQuestion);