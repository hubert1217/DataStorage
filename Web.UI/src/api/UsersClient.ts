import { User } from "../store/user/models";

class UserClient {

    async getAll(): Promise<User[]> {
        const response = await fetch("https://localhost:7093/users/getall");
    
        if (!response.ok) {
            throw new Error("Błąd sieci!");
        }
    
        const data = await response.json();
    
        console.log(data);
    
        return data;
    }
}

export default new UserClient();