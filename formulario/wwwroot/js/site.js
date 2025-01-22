async function sendData() {
    //form information
    const name = document.getElementById('input-name').value || "";
    const cpf = document.getElementById('cpf').value || "";
    const rg = document.getElementById('rg').value || "";
    const e_mail = document.getElementById('e-mail').value || "";
    const dateBirth = document.getElementById('date-birth').value || "";
    const gender = document.getElementById('input-gender').value || "";
    const nationality = document.getElementById('input-nationality').value || "";
    const maritalStatus = document.getElementById('marital-status').value || "";

    //grounping information
    const data = {
        name,
        cpf,
        rg,
        e_mail,
        dateBirth,
        gender,
        nationality,
        maritalStatus
    };

    const url = "https://localhost:7006/api/Task";

    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            throw new Error("Erro ao enviar os dados para a API");
        }

        const responseData = await response.json(); 
        console.log("Resposta da API:", responseData);
    } catch (error) {
        console.error("Erro:", error);
    }
}

document.getElementById("send-button").addEventListener('click', sendData);
