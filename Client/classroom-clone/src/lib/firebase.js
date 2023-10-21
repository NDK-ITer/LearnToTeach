import firebase from "firebase";
import "firebase/firestore";

const firebaseConfig = {
  apiKey: "AIzaSyDGZvjMMT9NX9N-jGA_8UggeKrJf4XYtbk",
  authDomain: "e-learning-80479.firebaseapp.com",
  projectId: "e-learning-80479",
  storageBucket: "e-learning-80479.appspot.com",
  messagingSenderId: "897219679360",
  appId: "1:897219679360:web:d8d73702afb3a89db04265",
  measurementId: "G-8CTD80XTX8"
};

firebase.initializeApp(firebaseConfig);

const db = firebase.firestore();
const auth = firebase.auth();
const provider = new firebase.auth.GoogleAuthProvider();
const storage = firebase.storage();

export { auth, provider, storage };
export default db;
