export default function getFileExtension(filename) {
    return filename.split('.').pop(); // Split the filename by '.' and get the last element (the extension)
}
