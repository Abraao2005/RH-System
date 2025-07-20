import { Routes } from '@angular/router';
import { Principal } from './pages/principal/principal';
import { Funcionarios } from './pages/funcionarios/funcionarios';
import { Ferias } from './pages/ferias/ferias';
import { Relatorio } from './pages/relatorio/relatorio';

export const routes: Routes = [
  { path: '', component: Principal },
  { path: 'funcionarios', component: Funcionarios },
  { path: 'ferias', component: Ferias },
  { path: 'relatorio', component: Relatorio },
];