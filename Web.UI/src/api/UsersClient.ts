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

  async update(
    id: number,
    firstName: string,
    lastName: string,
    description: string,
    email: string
  ): Promise<User> {
    const response = await fetch(`https://localhost:7093/users/update/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        id,
        firstName,
        lastName,
        description,
        email,
      }),
    });

    if (!response.ok) {
      throw new Error("Błąd sieci podczas aktualizacji użytkownika!");
    }

    const updatedUser = await response.json();
    return updatedUser;
  }

  async add(
    firstName: string,
    lastName: string,
    description: string,
    email: string
  ): Promise<User> {
    const response = await fetch(`https://localhost:7093/users/create`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        firstName,
        lastName,
        description,
        email,
      }),
    });

    if (!response.ok) {
      throw new Error("Błąd sieci podczas aktualizacji użytkownika!");
    }

    const addedUser = await response.json();
    return addedUser;
  }

//   async delete(id: number) {
//     return await fetch(`https://localhost:7093/users/delete/${id}`, {
//       method: "DELETE",
//       headers: {
//         "Content-Type": "application/json",
//       },
//     });
//   }
// }

async delete(id: number) {
    try {
      const response = await fetch(`https://localhost:7093/users/delete/${id}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      });
  
      if (!response.ok) {
        throw new Error(`Failed to delete user with ID ${id}`);
      }
  
      return response;
    } catch (error) {
      console.error("Delete error:", error);
      throw error;
    }
  }
  
}
export default new UserClient();
