export default function formatDate(inputDate) {
    const date = new Date(inputDate);

    const seconds = date.getSeconds().toString().padStart(2, '0');
    const minutes = date.getMinutes().toString().padStart(2, '0');
    const hours = date.getHours().toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Months are 0-indexed, so adding 1
    const year = date.getFullYear().toString();

    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
}