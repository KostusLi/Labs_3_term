
const form = document.querySelector("form");

form.addEventListener("submit", function(event) {
    const city = document.getElementById("city").value.trim();
    const bstu = document.getElementById("bstu").checked;
    
    const course = document.querySelector('input[name="check"]:checked')?.value;

    let isValid = true;
    let message = "Вы указали следующие данные:\n";

    if (city !== "Минск") {
        isValid = false;
        message += `- Город: ${city}\n`;
    }

    if (course !== "3") {
        isValid = false;
        message += `- Курс: ${course}\n`;
    }

    if (!bstu) {
        isValid = false;
        message += `- Вы не отметили, что учитесь в БГТУ\n`;
    }

    if (!isValid) {
        const confirmSend = confirm(
            message + "\nВы уверены, что хотите отправить форму с этими данными?"
        );

        if (!confirmSend) {
            event.preventDefault();
        }
    }
});
