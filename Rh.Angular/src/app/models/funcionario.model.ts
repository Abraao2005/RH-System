export interface Funcionario {
  id: number;
  name: string;
  office: string;
  dateAdmission: string;
  active: boolean;
}

export interface FuncionarioResponse {
  data: Funcionario[];
  message: string;
}