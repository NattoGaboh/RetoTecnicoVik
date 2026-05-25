export interface AuthResponse {
  success: boolean;
  data: {
    token: string;
    username: string;
    role: string;
  };
}