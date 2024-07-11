let cardNumber = "1234 5678 1234 5678";   
let cardPin = "1234";   
const depositAmount = 20000;
const withdrawAmount = 10000;

const validateCard = async (cardNumber) => {
  try {
    if (!cardNumber && cardNumber.length === 16) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const validatePin = async (cardNumber, cardPin) => {
  try {
    if (!cardNumber && !cardPin && cardPin.length === 4) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const deposit = async (cardNumber, Amount) => {
  try {
    if (!cardNumber && Amount > 0 && depositAmount <= Amount) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const withdraw = async (cardNumber, cardPin, Amount) => {
  try {
    if (!cardNumber && !cardPin && Amount > 0 && withdrawAmount <= Amount) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

const checkBalance = async (cardNumber, cardPin) => {
  try {
    if (!cardNumber && !cardPin) {
      return false;
    }
    const data = await fetch(`url`)
      .then((response) => response.json())
      .catch((error) => console.error(error));

    if (data) {
      return true;
    }
  } catch (error) {
    console.error(error);
  }
};

async function checkCardNumber(){
    const cardNum = document.getElementById('card-number').value;
    if(cardNum.length != 16){
        showError('Please enter valid card number' , 'card-number' , 'card-number-error-container');
    }
    else{
       makeErrorNone('card-number' , 'card-number-error-container')
    }

    // const result = await validateCard(cardNum);
    result = true;
    if(result){
        makeAllContainerDisplayNone();
        document.getElementById('services-container').style.display = 'flex'
    }
}

async function showBalance(){
  const balance =  await checkBalance();
  document.getElementById('balance').innerHTML = balance;
  makeAllContainerDisplayNone();
  document.getElementById('balance-container').style.display = 'flex'
}

function showError(message , inputBoxId , errorContainerId){
    const inputBox = document.getElementById(inputBoxId);
    const errorContainer = document.getElementById(errorContainerId);
    inputBox.style.borderColor = 'Red';
    inputBox.style.outlineColor = 'Red';
    errorContainer.innerHTML = message;
}

function makeErrorNone(inputBoxId , errorContainerId){
   const inputBox = document.getElementById(inputBoxId);
    const errorContainer = document.getElementById(errorContainerId);
    inputBox.style.borderColor = 'black';
    inputBox.style.outlineColor = 'black';
    errorContainer.style.display = 'none'
}

function makeAllContainerDisplayNone(){
  document.getElementById('card-container').style.display = 'none'
  document.getElementById('pin-container').style.display = 'none'
  document.getElementById('deposit-container').style.display = 'none'
  document.getElementById('withdraw-container').style.display = 'none'
  document.getElementById('balance-container').style.display = 'none'
  document.getElementById('otp-container').style.display = 'none'
  document.getElementById('services-container').style.display='none'
}
