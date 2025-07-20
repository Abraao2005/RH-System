import { Component, OnInit } from '@angular/core';
import { Funcionario } from '../../models/funcionario.model';
import { FuncionariosService } from '../../services/funcionarios';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-funcionarios',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './funcionarios.html',
  styleUrl: './funcionarios.scss'
})
export class Funcionarios implements OnInit {
  funcionarios: Funcionario[] = [];

  constructor(private funcService: FuncionariosService) { }

  ngOnInit(): void {
    this.funcService.listar().subscribe(response => {
      this.funcionarios = response.data;
    });
  }
}