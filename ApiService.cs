using Newtonsoft.Json;
using Refit;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElearningDesktop
{
    public class SerieQueryParameters
    {
        public string curso { get; set; }
        public string ano { get; set; }
        public string tipo { get; set; }
        public string periodo { get; set; }
    }

    public class TeacherQueryParameters
    {
        [AliasAs("rg")]
        public string RG { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }
    }

    public class StudentQueryParameters
    {
        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }

        [AliasAs("idSerie")]
        public int IdSerie { get; set; }
    }

    public class ClassQueryParameters
    {
        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("idCores")]
        public int? IdCores { get; set; }

        [AliasAs("idIcone")]
        public int? IdIcone { get; set; }

        [AliasAs("idSerie")]
        public int? IdSerie { get; set; }

        [AliasAs("rgProfessor")]
        public string RgProfessor { get; set; }

        [AliasAs("icone")]
        public IconsApiResponse Icone { get; set; }

        [AliasAs("cores")]
        public ColorsApiResponse Colors { get; set; }
    }

    public class StudentQueryGet
    {
        [AliasAs("ra")]
        public int? RA { get; set; }

        [AliasAs("telefone")]
        public string Telefone { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("foto")]
        public string Foto { get; set; }

        [AliasAs("idSerie")]
        public int? IdSerie { get; set; }
    }

    public class ClassQueryGet
    {
        [AliasAs("id")]
        public int? ID { get; set; }

        [AliasAs("nome")]
        public string Nome { get; set; }

        [AliasAs("idSerie")]
        public int? IdSerie { get; set; }

        [AliasAs("rgProfessor")]
        public string RgProfessor { get; set; }
    }

    interface ApiService
    {
        #region Rotas de Séries
        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/series/")]
        Task<dynamic> GetSeriesAsync();

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/series/")]
        Task<dynamic> GetSeriesFilteredAsync(SerieQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/series/")]
        Task<dynamic> InsertSeriesAsync([Body] SerieQueryParameters parametros);
        #endregion

        #region Rotas de Professores
        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/professores/")]
        Task<dynamic> GetTeachersAsync();

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/professores/")]
        Task<dynamic> GetTeachersFilteredAsync(TeacherQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/professores/")]
        Task<dynamic> InsertTeachersAsync([Body] TeacherQueryParameters parametros);
        #endregion

        #region Rotas de Alunos
        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/alunos/")]
        Task<dynamic> GetStudentsAsync();

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/alunos/")]
        Task<dynamic> GetStudentsFilteredAsync(StudentQueryGet parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/alunos/")]
        Task<dynamic> InsertStudentsAsync([Body] StudentQueryParameters parametros);
        #endregion

        #region Rotas de Turmas
        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/turmas/")]
        Task<dynamic> GetTurmasAsync();

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/turmas/")]
        Task<dynamic> GetTurmasFilteredAsync(ClassQueryGet parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Post("/turmas/")]
        Task<dynamic> InsertTurmasAsync([Body] ClassQueryParameters parametros);

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/icones/")]
        Task<dynamic> GetIconsAsync();

        [Headers("basic_token: 7631c0f15fc888a088c5f0c28047aaef")]
        [Get("/cores/")]
        Task<dynamic> GetColorsAsync();
        #endregion

        #region Enviar Imagem para Servidor
        [Multipart]
        [Post("/arquivos/")]
        Task<dynamic> SendImageToApi( ByteArrayPart file);
        #endregion
    }
}